﻿namespace DiffSharp.Util

open System
open System.Collections.Generic
open System.Diagnostics.CodeAnalysis
open System.IO
open System.IO.Compression
open System.Text
open System.Net
open System.Runtime.Serialization
open System.Runtime.Serialization.Formatters.Binary
open SixLabors.ImageSharp
open SixLabors.ImageSharp.Processing

/// <summary>
///   Contains extensions to the F# Array module. 
/// </summary>
///
/// <namespacedoc>
///   <summary>Contains utilities and library extensions related to the DiffSharp programming model.</summary>
/// </namespacedoc>
module Array =

    /// Determines if all values of the first array lie within the given tolerances of the second array.
    [<ExcludeFromCodeCoverage>]
    let inline allClose (relativeTolerance:'T) (absoluteTolerance:'T) (array1:'T[]) (array2:'T[]) =
        let dim1 = array1.Length
        let dim2 = array2.Length
        if dim1 <> dim2 then false
        else (array1,array2) ||> Array.forall2 (fun a b -> abs(a-b) <= absoluteTolerance + relativeTolerance*abs(b)) 

    /// Gets the cumulative sum of the input array.
    [<ExcludeFromCodeCoverage>]
    let inline cumulativeSum (a:_[]) = (Array.scan (+) LanguagePrimitives.GenericZero a).[1..]

    /// Gets the unique counts of the input array.
    let getUniqueCounts (sorted:bool) (values:'T[]) =
        let counts = Dictionary<'T, int>()
        for v in values do
            if counts.ContainsKey(v) then counts.[v] <- counts.[v] + 1 else counts.[v] <- 1
        if sorted then
            counts |> Array.ofSeq |> Array.sortByDescending (fun (KeyValue(_, v)) -> v) |> Array.map (fun (KeyValue(k, v)) -> k, v) |> Array.unzip
        else
            counts |> Array.ofSeq |> Array.map (fun (KeyValue(k, v)) -> k, v) |> Array.unzip

/// Contains extensions to the F# Seq module. 
module Seq =

    /// Gets the index of the maximum element of the sequence.
    let maxIndex seq =  seq |> Seq.mapi (fun i x -> i, x) |> Seq.maxBy snd |> fst

    /// Gets the index of the minimum element of the sequence.
    let minIndex seq =  seq |> Seq.mapi (fun i x -> i, x) |> Seq.minBy snd |> fst

    /// Indicates if all elements of the sequence are equal.
    let allEqual (items:seq<'T>) =
        let item0 = items |> Seq.head
        items |> Seq.forall ((=) item0)

    /// Gets the duplicate elements in the sequence.
    let duplicates l =
       l |> List.ofSeq
       |> List.groupBy id
       |> List.choose ( function
              | _, x::_::_ -> Some x
              | _ -> None )

    /// Indicates if a sequence has duplicate elements.
    let hasDuplicates l =
        duplicates l |> List.isEmpty |> not

    /// Like Seq.toArray but does not clone the array if the input is already an array
    let inline toArrayQuick (xs: seq<'T>) =
        match xs with
        | :? ('T[]) as arr -> arr
        | _ -> Seq.toArray xs

/// Contains extensions related to .NET dictionaries. 
module Dictionary =

    /// Gets a fresh array containing the keys of the dictionary.
    let copyKeys (dictionary:Dictionary<'Key, 'Value>) =
        let keys = Array.zeroCreate dictionary.Count
        dictionary.Keys.CopyTo(keys, 0)
        keys

    /// Gets a fresh array containing the values of the dictionary.
    let copyValues (dictionary:Dictionary<'Key, 'Value>) =
        let values = Array.zeroCreate dictionary.Count
        dictionary.Values.CopyTo(values, 0)
        values

/// Contains auto-opened extensions to the F# programming model.
[<AutoOpen>]
module ExtensionAutoOpens =

    /// Indicates if a value is not null.
    [<ExcludeFromCodeCoverage>]
    let inline notNull value = not (obj.ReferenceEquals(value, null))

    /// Returns a function that memoizes the given function using a lookaside table.
    let memoize fn =
        let cache = new Dictionary<_,_>()
        fun x ->
            match cache.TryGetValue x with
            | true, v -> v
            | false, _ ->
                let v = fn x
                cache.Add(x,v)
                v

    /// Synchronously downloads the given URL to the given local file.
    let download (url:string) (localFileName:string) =
        let wc = new WebClient()
        printfn "Downloading %A to %A" url localFileName
        wc.DownloadFile(url, localFileName)
        wc.Dispose()

    /// Saves the given value to the given local file using binary serialization.
    let saveBinary (object: 'T) (fileName:string) =
        let formatter = BinaryFormatter()
        let fs = new FileStream(fileName, FileMode.Create)
        let cs = new GZipStream(fs, CompressionMode.Compress)
        try
            formatter.Serialize(cs, object)
            cs.Flush()
            cs.Close()
            fs.Close()
        with
        | :? SerializationException as e -> failwithf "Cannot save to file. %A" e.Message

    /// Loads the given value from the given local file using binary serialization.
    let loadBinary (fileName:string):'T =
        let formatter = BinaryFormatter()
        let fs = new FileStream(fileName, FileMode.Open)
        let cs = new GZipStream(fs, CompressionMode.Decompress)
        try
            let object = formatter.Deserialize(cs) :?> 'T
            cs.Close()
            fs.Close()
            object
        with
        | :? SerializationException as e -> failwithf "Cannot load from file. %A" e.Message

    /// Saves the given pixel array to a file and optionally resizes it in the process. Resizing uses bicubic interpolation. Supports .png and .jpg formats.
    let saveImage (pixels:float32[,,]) (fileName:string) (resize:option<int*int>) =
        let c, h, w = pixels.GetLength(0), pixels.GetLength(1), pixels.GetLength(2)
        let image = new Image<PixelFormats.RgbaVector>(w, h)
        for y=0 to h-1 do
            for x=0 to w-1 do
                let r, g, b = 
                    if c = 1 then
                        let v = float32(pixels.[0, y, x])
                        v, v, v
                    else
                        float32(pixels.[0, y, x]), float32(pixels.[1, y, x]), float32(pixels.[2, y, x])
                image.Item(x, y) <- PixelFormats.RgbaVector(r, g, b)
        let fs = new FileStream(fileName, FileMode.Create)
        let encoder =
            if fileName.EndsWith(".jpg") then
                Formats.Jpeg.JpegEncoder() :> Formats.IImageEncoder
            elif fileName.EndsWith(".png") then
                Formats.Png.PngEncoder() :> Formats.IImageEncoder
            else
                failwithf "Expecting fileName (%A) to end with .png or .jpg" fileName
        match resize with
            | Some(width, height) ->
                if width < 0 || height < 0 then failwithf "Expecting width (%A) and height (%A) >= 0" width height
                image.Mutate(Action<IImageProcessingContext>(fun x -> x.Resize(width, height) |> ignore))
            | None -> ()
        image.Save(fs, encoder)
        fs.Close()

    /// Loads a pixel array from a file and optionally resizes it in the process. Resizing uses bicubic interpolation.
    let loadImage (fileName:string) (resize:option<int*int>) =
        let image:Image<PixelFormats.RgbaVector> = Image.Load(fileName)
        match resize with
            | Some(width, height) ->
                if width < 0 || height < 0 then failwithf "Expecting width (%A) and height (%A) >= 0" width height
                image.Mutate(Action<IImageProcessingContext>(fun x -> x.Resize(width, height) |> ignore))
            | None -> ()
        let pixels = Array3D.init 3 image.Height image.Width (fun c y x -> let p = image.Item(x, y)
                                                                           if c = 0 then p.R
                                                                           elif c = 1 then p.G
                                                                           else p.B)
        pixels

    let extractTarStream (stream:Stream) (outputDir:string) =
        let buffer:byte[] = Array.zeroCreate 100
        let mutable stop = false
        while not stop do
            stream.Read(buffer, 0, 100) |> ignore
            let name = Encoding.ASCII.GetString(buffer).Trim(Convert.ToChar(0)).Trim()
            if String.IsNullOrWhiteSpace(name) then stop <- true
            if not stop then
                stream.Seek(24L, SeekOrigin.Current) |> ignore
                stream.Read(buffer, 0, 12) |> ignore
                let size = Convert.ToInt32(Encoding.ASCII.GetString(buffer, 0, 12).Trim(Convert.ToChar(0)).Trim(), 8)
                printfn "Extracting %A (%A Bytes)" name size
                stream.Seek(376L, SeekOrigin.Current) |> ignore
                let output = Path.Combine(outputDir, name)
                if not (Directory.Exists(Path.GetDirectoryName(output))) then
                    Directory.CreateDirectory(Path.GetDirectoryName(output)) |> ignore
                if size > 0 then
                    let str = File.Open(output, FileMode.OpenOrCreate, FileAccess.Write)
                    let buf:byte[] = Array.zeroCreate size
                    stream.Read(buf, 0, buf.Length) |> ignore
                    str.Write(buf, 0, buf.Length)
                    str.Close()
                let pos = stream.Position
                let mutable offset = 512L - (pos % 512L)
                if offset = 512L then
                    offset <- 0L
                stream.Seek(offset, SeekOrigin.Current) |> ignore

    let extractTarGz (fileName:string) (outputDir:string) =
        let fs = File.OpenRead(fileName)
        let gz = new GZipStream(fs, CompressionMode.Decompress)
        let chunk = 4096
        let memstr = new MemoryStream()
        let mutable read = chunk
        let buffer:byte[] = Array.zeroCreate chunk
        while read = chunk do
            read <- gz.Read(buffer, 0, chunk)
            memstr.Write(buffer, 0, read)
        gz.Close()
        fs.Close()
        memstr.Seek(0L, SeekOrigin.Begin) |> ignore
        extractTarStream memstr outputDir
        memstr.Close()

    /// Value of log(sqrt(2*Math.PI)).
    let logSqrt2Pi = log(sqrt(2. * Math.PI))

    /// Value of log(10).
    let log10Val = log 10.

    /// Indents all lines of the given string by the given number of spaces.
    let indentNewLines (str:String) numSpaces =
        let mutable ret = ""
        let spaces = String.replicate numSpaces " "
        str |> Seq.toList |> List.iter (fun c -> 
                            if c = '\n' then 
                                ret <- ret + "\n" + spaces
                            else ret <- ret + string c)
        ret

    /// Left-pads a string up to the given length.
    let stringPad (s:string) (width:int) =
        if s.Length > width then s
        else String.replicate (width - s.Length) " " + s

    /// Left-pads a string to match the length of another string.
    let stringPadAs (s1:string) (s2:string) = stringPad s1 s2.Length

    /// Creates a non-jagged 3D array from jagged data.
    let array3D data = 
        let data = data |> Array.ofSeq |> Array.map array2D
        let r1, r2, r3 = data.Length, data.[0].GetLength(0), data.[0].GetLength(1)
        for i in 0 .. r1-1 do 
            let q2 = data.[i].GetLength(0)
            let q3 = data.[i].GetLength(1)
            if q2 <> r2 || q3 <> r3 then 
                invalidArg "data" (sprintf "jagged input at position %d: first is _ x %d x %d, later is _ x _ x %d x %d" i r2 r3 q2 q3)
        Array3D.init r1 r2 r3 (fun i j k -> data.[i].[j,k])

    /// Creates a non-jagged 4D array from jagged data.
    let array4D data = 
        let data = data |> array2D |> Array2D.map array2D
        let r1,r2,r3,r4 = (data.GetLength(0), data.GetLength(1), data.[0,0].GetLength(0),data.[0,0].GetLength(1))
        for i in 0 .. r1-1 do 
          for j in 0 .. r2-1 do 
            let q3 = data.[i,j].GetLength(0)
            let q4 = data.[i,j].GetLength(1)
            if q3 <> r3 || q4 <> r4 then 
                invalidArg "data" (sprintf "jagged input at position (%d,%d): first is _ x _ x %d x %d, later is _ x _ x %d x %d" i j r2 r3 q3 q4)
        Array4D.init r1 r2 r3 r4 (fun i j k m -> data.[i,j].[k,m])

    /// Initializes an array with a given shape and initializer function.
    let arrayND (shape: int[]) f =
        match shape with 
        | [| |] -> f [| |] |> box
        | [| d0 |] -> Array.init d0 (fun i -> f [| i |]) |> box
        | [| d0; d1 |] -> Array2D.init d0 d1 (fun i1 i2 -> f [| i1; i2 |]) |> box
        | [| d0; d1; d2 |] -> Array3D.init d0 d1 d2 (fun i1 i2 i3 -> f [| i1; i2; i3 |]) |> box
        | [| d0; d1; d2; d3 |] -> Array4D.init d0 d1 d2 d3 (fun i1 i2 i3 i4 -> f [| i1; i2; i3; i4 |]) |> box
        | _ -> failwith "arrayND - nyi for dim > 4"

    /// Print the given value to the console using the '%A' printf format specifier
    let print x = printfn "%A" x 

