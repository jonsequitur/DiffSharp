namespace rec DiffSharp.Model
open DiffSharp
open DiffSharp.Util
open System.Collections.Generic


/// <summary>TBD</summary>
type Parameter =
    val mutable value:Tensor
    new(value) = {value=value}

    /// <summary>TBD</summary>
    member p.forwardDiff(derivative:Tensor, ?tag:uint32) = p.value <- p.value.forwardDiff(derivative, ?tag=tag)

    /// <summary>TBD</summary>
    member p.reverseDiff(?tag:uint32) = p.value <- p.value.reverseDiff(?tag=tag)

    /// <summary>TBD</summary>
    member p.noDiff() = p.value <- p.value.noDiff()

    /// <summary>TBD</summary>
    member p.move(?dtype, ?device, ?backend) = p.value <- p.value.move(?dtype=dtype, ?device=device, ?backend=backend)

    /// <summary>TBD</summary>
    override p.ToString() = sprintf "Parameter(shape:%A, value:%A)" p.value.shape p.value


/// <summary>TBD</summary>
type ParameterDict() =

    /// <summary>TBD</summary>
    member val values = Dictionary<string, Parameter>()

    /// <summary>TBD</summary>
    member d.Item
        with get key = d.values.[key].value
        and set key v = d.values.[key].value <- v

    /// <summary>TBD</summary>
    member d.add(name, parameter) = d.values.Add(name, parameter)

    /// <summary>TBD</summary>
    member d.add(parameters:list<string*Parameter>) = for (n, p) in parameters do d.add(n, p)

    /// <summary>TBD</summary>
    member d.add(parameters:ParameterDict) = for KeyValue(n, p) in parameters.values do d.add(n, p)

    /// <summary>TBD</summary>
    member d.copy() = d.map(fun (t:Tensor) -> t)

    /// <summary>TBD</summary>
    member d.map(f:string*Parameter->string*Parameter) =
        let ret = ParameterDict()
        for KeyValue(n, p) in d.values do ret.values.Add(f(n,p))
        ret

    /// <summary>TBD</summary>
    member d.map(f:string*Tensor->string*Tensor) = d.map(fun (n, p:Parameter) -> let nn, tt = f(n, p.value) in nn, Parameter(tt))

    /// <summary>TBD</summary>
    member d.map(f:Tensor->Tensor) = d.map(fun (n,t) -> n, f t)

    /// <summary>TBD</summary>
    member d.set(parameters:ParameterDict) = d.iter(fun (n, p) -> p.value <- parameters.[n])

    /// <summary>TBD</summary>
    member d.iter(f:string*Parameter->unit) = for KeyValue(n, p) in d.values do f(n,p)

    /// <summary>TBD</summary>
    member d.forwarddiff(derivatives:ParameterDict, ?tag:uint32) = 
        let tag = defaultArg tag GlobalNestingLevel.Current
        d.iter(fun (n, p) -> p.forwardDiff(derivatives.[n], tag))

    /// <summary>TBD</summary>
    member d.reverseDiff(?tag:uint32) = 
        let tag = defaultArg tag GlobalNestingLevel.Current
        d.iter(fun (_, p) -> p.reverseDiff(tag))

    /// <summary>TBD</summary>
    member d.noDiff() = d.iter(fun (_, p) -> p.noDiff())

    /// <summary>TBD</summary>
    member d.move(?dtype, ?device, ?backend) = d.iter (fun (_, p) -> p.move(?dtype=dtype, ?device=device, ?backend=backend))

    /// <summary>TBD</summary>
    member d.primal with get() = d.map(fun (t:Tensor)->t.primal)

    /// <summary>TBD</summary>
    member d.derivative with get() = d.map(fun (t:Tensor)->t.derivative)

    /// <summary>TBD</summary>
    member d.nelement with get() = [|for t in d.values.Values do t.value.nelement|] |> Array.sum

    /// <summary>TBD</summary>
    member d.flatten() =
        let ts = [for t in d.values.Values do t.value.view(-1)]
        dsharp.cat(ts)

    /// <summary>TBD</summary>
    member d.unflatten(tensors:Tensor) =
        if tensors.dim <> 1 then failwithf "Expecting 1d tensors but received tensors with shape %A" tensors.shape
        if tensors.nelement <> d.nelement then failwithf "Expecting tensors.nelement (%A) and ParameterDict.nelement (%A) to be the same" tensors.nelement d.nelement
        let shapes = [|for t in d.values.Values do t.value.shape|]
        let sizes = [|for s in shapes do shapeLength s|]
        let ts = Array.map2 (fun (t:Tensor) (s:int[]) -> t.view(s)) (tensors.split(sizes)) shapes
        let mutable i = 0
        let keys = Dictionary.copyKeys d.values
        for n in keys do
            d.[n] <- ts.[i]
            i <- i+1

    /// <summary>TBD</summary>
    member d.unflattenToNew(tensors:Tensor) = 
        let dd = d.copy()
        dd.unflatten(tensors)
        dd

    /// <summary>TBD</summary>
    override d.ToString() =
        let sb = System.Text.StringBuilder()
        sb.Append("ParameterDict(") |> ignore
        let mutable prefix = ""
        for KeyValue(n, p) in d.values do 
            sb.Append(sprintf "%s%A:%A" prefix n p) |> ignore
            prefix <- ", "
        sb.Append(")") |> ignore
        sb.ToString()


/// <summary>TBD</summary>
type Mode =
    | Train = 0
    | Eval = 1

[<AbstractClass>]
/// <summary>TBD</summary>
type Model() =
    [<DefaultValue>]
    val mutable mode: Mode

    /// <summary>TBD</summary>
    member val ParametersDict = ParameterDict()

    /// <summary>TBD</summary>
    member val SubModelsDict = Dictionary<string, Model>()

    /// <summary>TBD</summary>
    member m.train() = 
        m.mode <- Mode.Train
        for model:Model in m.allModels do model.mode <- Mode.Train

    /// <summary>TBD</summary>
    member m.eval() = 
        m.mode <- Mode.Eval
        for model:Model in m.allModels do model.mode <- Mode.Eval

    /// <summary>TBD</summary>
    member m.parametersDict
        with get () = m.ParametersDict
        and set parameters = m.ParametersDict.set(parameters)

    /// <summary>TBD</summary>
    member m.parameters
        with get () = m.parametersDict.flatten()
        and set parameters = m.parametersDict.unflatten(parameters)

    /// <summary>TBD</summary>
    member m.allModels
        with get () =
            if m.SubModelsDict.Count = 0 then [m]
            else [for sm in m.SubModelsDict.Values do yield! sm.allModels]

    /// <summary>TBD</summary>
    member m.add(parameters:seq<obj>, ?names:seq<string>) =
        let parameters = parameters |> Seq.toArray
        let names = defaultArg names (Seq.init (parameters.Length) (fun i -> sprintf "m__%s__%d" (Random.UUID()) i)) |> Seq.toArray
        if parameters.Length <> names.Length then failwithf "Expecting parameters.Length (%A) and names.Length (%A) to be same" parameters.Length names.Length
        for p, n in Array.zip parameters names do
            match (box p) with
            | :? Parameter as p -> 
                m.parametersDict.add(n, p)
            | :? Model as mm ->
                m.SubModelsDict.Add(n, mm)
                m.parametersDict.add(mm.parametersDict.map(fun (nn, pp:Parameter) -> (n + "__" + nn, pp)))
            | _ -> failwithf "Unsupported type. Expecting a Parameter or Model"

    /// <summary>TBD</summary>
    member m.forwardDiff(derivatives:ParameterDict) = m.parametersDict.forwarddiff(derivatives)

    /// <summary>TBD</summary>
    member m.reverseDiff() = m.parametersDict.reverseDiff()

    /// <summary>TBD</summary>
    member m.noDiff() = m.parametersDict.noDiff()

    /// <summary>TBD</summary>
    member m.move(?dtype, ?device, ?backend) = m.parametersDict.move(?dtype=dtype, ?device=device, ?backend=backend)

    /// <summary>TBD</summary>
    member m.nparameters = m.parametersDict.nelement

    /// <summary>TBD</summary>
    abstract member forward: Tensor -> Tensor

    /// <summary>TBD</summary>
    member m.forwardParameters (input:Tensor) (parameters:Tensor) =
        m.parameters <- parameters
        let f = m.forward(input) in m.noDiff(); f

    /// <summary>TBD</summary>
    member m.forwardCompose (f:Tensor->Tensor) (input:Tensor) (parameters:Tensor) =
        m.forwardParameters input parameters |> f

    /// <summary>TBD</summary>
    member m.forwardLoss (f:Tensor->Tensor->Tensor) (input:Tensor) (target:Tensor) (parameters:Tensor) =
        m.forwardCompose (f target) input parameters

    /// <summary>TBD</summary>
    static member create ps f =
        let model = { new Model() with override __.forward(x) = f x}
        model.add(ps)
        model

    /// <summary>TBD</summary>
    override m.ToString() =
        let sb = System.Text.StringBuilder()
        sb.Append("Model(\n") |> ignore
        for model in m.allModels do sb.Append(sprintf "%A\n" model) |> ignore
        sb.Append(")") |> ignore
        sb.ToString()

    /// <summary>TBD</summary>
    static member compose (m1:Model) (m2:Model) = Model.create [m1; m2] (m1.forward >> m2.forward)

    /// <summary>TBD</summary>
    static member (-->) (m1:Model, m2:Model) = Model.compose m1 m2

    /// <summary>TBD</summary>
    static member (-->) (m:Model, f:Tensor->Tensor) = Model.create [m] (m.forward >> f)

    /// <summary>TBD</summary>
    static member (-->) (f:Tensor->Tensor, m:Model) = Model.create [m] (f >> m.forward)

    /// <summary>TBD</summary>
    static member (-->) (t:Tensor, m:Model) = m.forward t

    /// <summary>TBD</summary>
    member m.saveParameters(fileName) = m.parameters.save(fileName)

    /// <summary>TBD</summary>
    member m.loadParameters(fileName) = m.parameters <- Tensor.load(fileName)

    /// <summary>TBD</summary>
    member m.save(fileName) = saveBinary m fileName

    /// <summary>TBD</summary>
    static member load(fileName):Model = loadBinary fileName

    /// <summary>TBD</summary>
    member m.clone() = 
        let fileName = System.IO.Path.GetTempFileName()
        m.save(fileName)
        Model.load(fileName)

/// <summary>TBD</summary>
type Weight() =

    /// <summary>TBD</summary>
    static member kaiming(fanIn, fanOut, ?a:float) = 
        // He et al. 2015. https://arxiv.org/abs/1502.01852
        let a = defaultArg a (sqrt 5.)
        let w = dsharp.randn([fanIn; fanOut])
        let s = sqrt (2. / ((1. + a*a) * (float fanIn)))
        w * s

    /// <summary>TBD</summary>
    static member uniform(shape:int[], k:float) =
        -k + dsharp.rand(shape) * 2*k


/// <summary>TBD</summary>
type Linear(inFeatures, outFeatures, ?bias:bool) =
    inherit Model()
    let bias = defaultArg bias true
    let w = Parameter(Weight.kaiming(inFeatures, outFeatures))
    let k = 1./sqrt (float outFeatures)
    let b = Parameter(if bias then Weight.uniform([|outFeatures|], k) else dsharp.zero())
    do base.add([w;b],["Linear__weight";"Linear__bias"])

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "Linear(%A, %A)" inFeatures outFeatures

    /// <summary>TBD</summary>
    override _.forward(value) =
        let f = dsharp.matmul(value, w.value)
        if bias then f + b.value else f


/// <summary>TBD</summary>
type Conv1d(inChannels:int, outChannels:int, kernelSize:int, ?stride:int, ?padding:int, ?dilation:int, ?bias:bool) =
    inherit Model()
    let bias = defaultArg bias true
    let k = 1./ sqrt (float (inChannels*kernelSize))
    let w = Parameter <| Weight.uniform([|outChannels; inChannels; kernelSize|], k)
    let b = Parameter <| if bias then Weight.uniform([|outChannels|], k) else dsharp.zero()
    do base.add([w;b],["Conv1d__weight";"Conv1d__bias"])

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "Conv1d(%A, %A, %A)" inChannels outChannels kernelSize

    /// <summary>TBD</summary>
    override _.forward(value) =
        let f = dsharp.conv1d(value, w.value, ?stride=stride, ?padding=padding, ?dilation=dilation)
        if bias then f + b.value.expand([value.shape.[0]; outChannels]).view([value.shape.[0]; outChannels; 1]) else f


/// <summary>TBD</summary>
type Conv2d(inChannels:int, outChannels:int, ?kernelSize:int, ?stride:int, ?padding:int, ?dilation:int, ?kernelSizes:seq<int>, ?strides:seq<int>, ?paddings:seq<int>, ?dilations:seq<int>, ?bias:bool) =
    inherit Model()
    let kernelSizes = 
        match kernelSize, kernelSizes with
        | Some _ , Some _ -> failwithf "Expecting only one of kernelSize, kernelSizes"
        | Some k, None -> [|k; k|]
        | None, Some k -> let k = k |> Array.ofSeq in if k.Length <> 2 then failwithf "Expecting kernelSizes to have length two" else k
        | _ -> [|1; 1|]
    let bias = defaultArg bias true
    let k = 1./ sqrt (float (inChannels*kernelSizes.[0]*kernelSizes.[1]))
    let w = Parameter <| Weight.uniform([|outChannels; inChannels; kernelSizes.[0]; kernelSizes.[1]|], k)
    let b = Parameter <| if bias then Weight.uniform([|outChannels|], k) else dsharp.zero()
    do base.add([w;b],["Conv2d__weight";"Conv2d__bias"])

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "Conv2d(%A, %A, %A)" inChannels outChannels kernelSizes

    /// <summary>TBD</summary>
    override _.forward(value) =
        let f = dsharp.conv2d(value, w.value, ?stride=stride, ?strides=strides, ?padding=padding, ?paddings=paddings, ?dilation=dilation, ?dilations=dilations)
        if bias then f + b.value.expand([value.shape.[0]; outChannels]).view([value.shape.[0]; outChannels; 1; 1]) else f


/// <summary>TBD</summary>
type Conv3d(inChannels:int, outChannels:int, ?kernelSize:int, ?stride:int, ?padding:int, ?dilation:int, ?kernelSizes:seq<int>, ?strides:seq<int>, ?paddings:seq<int>, ?dilations:seq<int>, ?bias:bool) =
    inherit Model()
    let kernelSizes = 
        match kernelSize, kernelSizes with
        | Some _ , Some _ -> failwithf "Expecting only one of kernelSize, kernelSizes"
        | Some k, None -> [|k; k; k|]
        | None, Some k -> let k = k |> Array.ofSeq in if k.Length <> 3 then failwithf "Expecting kernelSizes to have length three" else k
        | _ -> [|1; 1; 1|]
    let bias = defaultArg bias true
    let k = 1./ sqrt (float (inChannels*kernelSizes.[0]*kernelSizes.[1]*kernelSizes.[2]))
    let w = Parameter <| Weight.uniform([|outChannels; inChannels; kernelSizes.[0]; kernelSizes.[1]; kernelSizes.[2]|], k)
    let b = Parameter <| if bias then Weight.uniform([|outChannels|], k) else dsharp.zero()
    do base.add([w;b],["Conv3d__weight";"Conv3d__bias"])

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "Conv3d(%A, %A, %A)" inChannels outChannels kernelSizes

    /// <summary>TBD</summary>
    override _.forward(value) =
        let f = dsharp.conv3d(value, w.value, ?stride=stride, ?strides=strides, ?padding=padding, ?paddings=paddings, ?dilation=dilation, ?dilations=dilations)
        if bias then f + b.value.expand([value.shape.[0]; outChannels]).view([value.shape.[0]; outChannels; 1; 1; 1]) else f


/// <summary>TBD</summary>
type ConvTranspose1d(inChannels:int, outChannels:int, kernelSize:int, ?stride:int, ?padding:int, ?dilation:int, ?bias:bool) =
    inherit Model()
    let bias = defaultArg bias true
    let k = 1./ sqrt (float (inChannels*kernelSize))
    let w = Parameter <| Weight.uniform([|inChannels; outChannels; kernelSize|], k)
    let b = Parameter <| if bias then Weight.uniform([|outChannels|], k) else dsharp.zero()
    do base.add([w;b],["ConvTranspose1d__weight";"ConvTranspose1d__bias"])

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "ConvTranspose1d(%A, %A, %A)" inChannels outChannels kernelSize

    /// <summary>TBD</summary>
    override _.forward(value) =
        let f = dsharp.convTranspose1d(value, w.value, ?stride=stride, ?padding=padding, ?dilation=dilation)
        if bias then f + b.value.expand([value.shape.[0]; outChannels]).view([value.shape.[0]; outChannels; 1]) else f


/// <summary>TBD</summary>
type ConvTranspose2d(inChannels:int, outChannels:int, ?kernelSize:int, ?stride:int, ?padding:int, ?dilation:int, ?kernelSizes:seq<int>, ?strides:seq<int>, ?paddings:seq<int>, ?dilations:seq<int>, ?bias:bool) =
    inherit Model()
    let kernelSizes = 
        match kernelSize, kernelSizes with
        | Some _ , Some _ -> failwithf "Expecting only one of kernelSize, kernelSizes"
        | Some k, None -> [|k; k|]
        | None, Some k -> let k = k |> Array.ofSeq in if k.Length <> 2 then failwithf "Expecting kernelSizes to have length two" else k
        | _ -> [|1; 1|]
    let bias = defaultArg bias true
    let k = 1./ sqrt (float (inChannels*kernelSizes.[0]*kernelSizes.[1]))
    let w = Parameter <| Weight.uniform([|inChannels; outChannels; kernelSizes.[0]; kernelSizes.[1]|], k)
    let b = Parameter <| if bias then Weight.uniform([|outChannels|], k) else dsharp.zero()
    do base.add([w;b],["ConvTranspose2d__weight";"ConvTranspose2d__bias"])

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "ConvTranspose2d(%A, %A, %A)" inChannels outChannels kernelSizes

    /// <summary>TBD</summary>
    override _.forward(value) =
        let f = dsharp.convTranspose2d(value, w.value, ?stride=stride, ?strides=strides, ?padding=padding, ?paddings=paddings, ?dilation=dilation, ?dilations=dilations)
        if bias then f + b.value.expand([value.shape.[0]; outChannels]).view([value.shape.[0]; outChannels; 1; 1]) else f


/// <summary>TBD</summary>
type ConvTranspose3d(inChannels:int, outChannels:int, ?kernelSize:int, ?stride:int, ?padding:int, ?dilation:int, ?kernelSizes:seq<int>, ?strides:seq<int>, ?paddings:seq<int>, ?dilations:seq<int>, ?bias:bool) =
    inherit Model()
    let kernelSizes = 
        match kernelSize, kernelSizes with
        | Some _ , Some _ -> failwithf "Expecting only one of kernelSize, kernelSizes"
        | Some k, None -> [|k; k; k|]
        | None, Some k -> let k = k |> Array.ofSeq in if k.Length <> 3 then failwithf "Expecting kernelSizes to have length three" else k
        | _ -> [|1; 1; 1|]
    let bias = defaultArg bias true
    let k = 1./ sqrt (float (inChannels*kernelSizes.[0]*kernelSizes.[1]*kernelSizes.[2]))
    let w = Parameter <| Weight.uniform([|inChannels; outChannels; kernelSizes.[0]; kernelSizes.[1]; kernelSizes.[2]|], k)
    let b = Parameter <| if bias then Weight.uniform([|outChannels|], k) else dsharp.zero()
    do base.add([w;b],["ConvTranspose3d__weight";"ConvTranspose3d__bias"])

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "ConvTranspose3d(%A, %A, %A)" inChannels outChannels kernelSizes

    /// <summary>TBD</summary>
    override _.forward(value) =
        let f = dsharp.convTranspose3d(value, w.value, ?stride=stride, ?strides=strides, ?padding=padding, ?paddings=paddings, ?dilation=dilation, ?dilations=dilations)
        if bias then f + b.value.expand([value.shape.[0]; outChannels]).view([value.shape.[0]; outChannels; 1; 1; 1]) else f


/// <summary>TBD</summary>
type Dropout(?p:double) =
    inherit Model()

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "Dropout()"

    /// <summary>TBD</summary>
    override m.forward(value) =
        if m.mode = Mode.Train then value.dropout(?p=p) else value


/// <summary>TBD</summary>
type Dropout2d(?p:double) =
    inherit Model()

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "Dropout2d()"

    /// <summary>TBD</summary>
    override m.forward(value) =
        if m.mode = Mode.Train then value.dropout2d(?p=p) else value


/// <summary>TBD</summary>
type Dropout3d(?p:double) =
    inherit Model()

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "Dropout3d()"

    /// <summary>TBD</summary>
    override m.forward(value) =
        if m.mode = Mode.Train then value.dropout3d(?p=p) else value


/// <summary>TBD</summary>
type BatchNorm1d(numFeatures:int, ?eps:double, ?momentum:Tensor, ?affine:bool, ?trackRunningStats:bool, ?reversible:bool) =
    inherit Model()
    let eps = defaultArg eps 1e-5
    let momentum = defaultArg momentum (dsharp.tensor(0.1))
    let affine = defaultArg affine true
    let trackRunningStats = defaultArg trackRunningStats true
    let reversible = defaultArg reversible false
    let w = Parameter <| if affine then dsharp.ones(numFeatures) else dsharp.zero() // gamma
    let b = Parameter <| if affine then dsharp.zeros(numFeatures) else dsharp.zero() // beta
    let _mean = Parameter <| dsharp.zero()
    let _variance = Parameter <| dsharp.zero()
    do base.add([w;b],["BatchNorm1d__weight";"BatchNorm1d__bias"]) // We don't add mean and variance here because they hold running statistics and are not subject to gradient-based optimization

    /// <summary>TBD</summary>
    member _.mean = _mean.value

    /// <summary>TBD</summary>
    member _.variance = _variance.value

    /// <summary>TBD</summary>
    member _.stddev = _variance.value.sqrt()

    /// <summary>TBD</summary>
    member _.weight = w.value

    /// <summary>TBD</summary>
    member _.bias = b.value

    member private _.updateStats (batchMean:Tensor) (batchVariance:Tensor) (n:int) =
        let batchMean = if reversible then batchMean else batchMean.primal
        let batchVariance = if reversible then batchVariance else batchVariance.primal
        _mean.value <- (1 - momentum) * _mean.value + momentum * batchMean
        // PyTorch seems to use unbiased variance (Bessel's correction) for running batchnorm statistics and biased variance for batch statistics. This seems strange and confusing but we adopt the same behavior for the time being.
        // https://github.com/pytorch/pytorch/issues/19902
        // https://discuss.pytorch.org/t/model-eval-gives-incorrect-loss-for-model-with-batchnorm-layers/7561/46
        // Here we transform biased variance to unbiased variance for running statistics
        let batchVariance = batchVariance * (float n) / (float n - 1.)
        _variance.value <- (1 - momentum) * _variance.value + momentum * batchVariance

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "BatchNorm1d(%A)" numFeatures

    /// <summary>TBD</summary>
    override m.forward(value) =
        if value.dim = 2 then
            if value.shape.[1] <> numFeatures then failwithf "Expecting value to have shape NxL (batchSize x numFeatures) where numFeatures=%A, received value with shape %A" numFeatures value.shape
            let mean, var =
                if m.mode = Mode.Train || (m.mode = Mode.Eval && not trackRunningStats) then
                    value.mean(0), value.variance(0, unbiased=false)
                else
                    _mean.value, _variance.value
            if m.mode = Mode.Train && trackRunningStats then 
                let batchSize = value.shape.[0]
                m.updateStats mean var batchSize
            let res = (value - mean) / (var + eps).sqrt()
            if affine then res * w.value + b.value else res
        elif value.dim = 3 then
            if value.shape.[1] <> numFeatures then failwithf "Expecting value to have shape NxCxL (batchSize x numFeatures x length) where numFeatures=%A, received value with shape %A" numFeatures value.shape
            let vt = value.transpose(0,1).view([numFeatures;-1])
            let mean, var =
                if m.mode = Mode.Train || (m.mode = Mode.Eval && not trackRunningStats) then
                    vt.mean(1), vt.variance(1, unbiased=false)
                else
                    _mean.value, _variance.value
            if m.mode = Mode.Train && trackRunningStats then
                let n = vt.shape.[1]
                m.updateStats mean var n
            let res = (value - mean.view([1;numFeatures;1])) / (var.view([1;numFeatures;1]) + eps).sqrt()
            if affine then res * w.value.view([1;numFeatures;1]) + b.value.view([1;numFeatures;1]) else res
        else failwithf "Expecting value to have shape NxL (batchSize x Length) or NxCxL (batchSize x numChannels x Length), received value with shape %A" value.shape


/// <summary>TBD</summary>
type BatchNorm2d(numFeatures:int, ?eps:double, ?momentum:Tensor, ?affine:bool, ?trackRunningStats:bool, ?reversible:bool) =
    inherit Model()
    let eps = defaultArg eps 1e-5
    let momentum = defaultArg momentum (dsharp.tensor(0.1))
    let affine = defaultArg affine true
    let trackRunningStats = defaultArg trackRunningStats true
    let reversible = defaultArg reversible false
    let w = Parameter <| if affine then dsharp.ones(numFeatures) else dsharp.zero() // gamma
    let b = Parameter <| if affine then dsharp.zeros(numFeatures) else dsharp.zero() // beta
    let _mean = Parameter <| dsharp.zero()
    let _variance = Parameter <| dsharp.zero()
    do base.add([w;b],["BatchNorm2d__weight";"BatchNorm2d__bias"]) // We don't add mean and variance here because they hold running statistics and are not subject to gradient-based optimization

    /// <summary>TBD</summary>
    member _.mean = _mean.value

    /// <summary>TBD</summary>
    member _.variance = _variance.value

    /// <summary>TBD</summary>
    member _.stddev = _variance.value.sqrt()

    /// <summary>TBD</summary>
    member _.weight = w.value

    /// <summary>TBD</summary>
    member _.bias = b.value

    member private _.updateStats (batchMean:Tensor) (batchVariance:Tensor) (n:int) =
        let batchMean = if reversible then batchMean else batchMean.primal
        let batchVariance = if reversible then batchVariance else batchVariance.primal
        _mean.value <- (1 - momentum) * _mean.value + momentum * batchMean
        // PyTorch seems to use unbiased variance (Bessel's correction) for running batchnorm statistics and biased variance for batch statistics. This seems strange and confusing but we adopt the same behavior for the time being.
        // https://github.com/pytorch/pytorch/issues/19902
        // https://discuss.pytorch.org/t/model-eval-gives-incorrect-loss-for-model-with-batchnorm-layers/7561/46
        // Here we transform biased variance to unbiased variance for running statistics
        let batchVariance = batchVariance * (float n) / (float n - 1.)
        _variance.value <- (1 - momentum) * _variance.value + momentum * batchVariance

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "BatchNorm2d(%A)" numFeatures

    /// <summary>TBD</summary>
    override m.forward(value) =
        if value.dim <> 4 || value.shape.[1] <> numFeatures then failwithf "Expecting value to have shape NxCxHxW (batchSize x numFeatures x height x width) where numFeatures=%A, received value with shape %A" numFeatures value.shape
        let vt = value.transpose(0,1).view([numFeatures;-1])
        let mean, var =
            if m.mode = Mode.Train || (m.mode = Mode.Eval && not trackRunningStats) then
                vt.mean(1), vt.variance(1, unbiased=false)
            else
                _mean.value, _variance.value
        if m.mode = Mode.Train && trackRunningStats then
            let n = vt.shape.[1]
            m.updateStats mean var n
        let res = (value - mean.view([1;numFeatures;1;1])) / (var.view([1;numFeatures;1;1]) + eps).sqrt()
        if affine then res * w.value.view([1;numFeatures;1;1]) + b.value.view([1;numFeatures;1;1]) else res


/// <summary>TBD</summary>
type BatchNorm3d(numFeatures:int, ?eps:double, ?momentum:Tensor, ?affine:bool, ?trackRunningStats:bool, ?reversible:bool) =
    inherit Model()
    let eps = defaultArg eps 1e-5
    let momentum = defaultArg momentum (dsharp.tensor(0.1))
    let affine = defaultArg affine true
    let trackRunningStats = defaultArg trackRunningStats true
    let reversible = defaultArg reversible false
    let w = Parameter <| if affine then dsharp.ones(numFeatures) else dsharp.zero() // gamma
    let b = Parameter <| if affine then dsharp.zeros(numFeatures) else dsharp.zero() // beta
    let _mean = Parameter <| dsharp.zero()
    let _variance = Parameter <| dsharp.zero()
    do base.add([w;b],["BatchNorm3d__weight";"BatchNorm3d__bias"]) // We don't add mean and variance here because they hold running statistics and are not subject to gradient-based optimization

    /// <summary>TBD</summary>
    member _.mean = _mean.value

    /// <summary>TBD</summary>
    member _.variance = _variance.value

    /// <summary>TBD</summary>
    member _.stddev = _variance.value.sqrt()

    /// <summary>TBD</summary>
    member _.weight = w.value

    /// <summary>TBD</summary>
    member _.bias = b.value

    member private _.updateStats (batchMean:Tensor) (batchVariance:Tensor) (n:int) =
        let batchMean = if reversible then batchMean else batchMean.primal
        let batchVariance = if reversible then batchVariance else batchVariance.primal
        _mean.value <- (1 - momentum) * _mean.value + momentum * batchMean
        // PyTorch seems to use unbiased variance (Bessel's correction) for running batchnorm statistics and biased variance for batch statistics. This seems strange and confusing but we adopt the same behavior for the time being.
        // https://github.com/pytorch/pytorch/issues/19902
        // https://discuss.pytorch.org/t/model-eval-gives-incorrect-loss-for-model-with-batchnorm-layers/7561/46
        // Here we transform biased variance to unbiased variance for running statistics
        let batchVariance = batchVariance * (float n) / (float n - 1.)
        _variance.value <- (1 - momentum) * _variance.value + momentum * batchVariance

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "BatchNorm3d(%A)" numFeatures

    /// <summary>TBD</summary>
    override m.forward(value) =
        if value.dim <> 5 || value.shape.[1] <> numFeatures then failwithf "Expecting value to have shape NxCxDxHxW (batchSize x numFeatures x depth x height x width) where numFeatures=%A, received value with shape %A" numFeatures value.shape
        let vt = value.transpose(0,1).view([numFeatures;-1])
        let mean, var =
            if m.mode = Mode.Train || (m.mode = Mode.Eval && not trackRunningStats) then
                vt.mean(1), vt.variance(1, unbiased=false)
            else
                _mean.value, _variance.value
        if m.mode = Mode.Train && trackRunningStats then
            let n = vt.shape.[1]
            m.updateStats mean var n
        let res = (value - mean.view([1;numFeatures;1;1;1])) / (var.view([1;numFeatures;1;1;1]) + eps).sqrt()
        if affine then res * w.value.view([1;numFeatures;1;1;1]) + b.value.view([1;numFeatures;1;1;1]) else res


/// <summary>Variational Auto-Encoder</summary>
type VAE(xDim:int, zDim:int, ?hDims:seq<int>, ?activation:Tensor->Tensor, ?activationLast:Tensor->Tensor) =
    inherit Model()
    let hDims = defaultArg hDims (let d = (xDim+zDim)/2 in seq [d; d]) |> Array.ofSeq
    let activation = defaultArg activation dsharp.relu
    let activationLast = defaultArg activationLast dsharp.sigmoid
    let dims =
        if hDims.Length = 0 then
            [|xDim; zDim|]
        else
            Array.append (Array.append [|xDim|] hDims) [|zDim|]
            
    let enc = Array.append [|for i in 0..dims.Length-2 -> Linear(dims.[i], dims.[i+1])|] [|Linear(dims.[dims.Length-2], dims.[dims.Length-1])|]
    let dec = [|for i in 0..dims.Length-2 -> Linear(dims.[i+1], dims.[i])|] |> Array.rev
    do 
        base.add([for m in enc -> box m])
        base.add([for m in dec -> box m])

    let encode x =
        let mutable x = x
        for i in 0..enc.Length-3 do
            x <- activation <| enc.[i].forward(x)
        let mu = enc.[enc.Length-2].forward(x)
        let logVar = enc.[enc.Length-1].forward(x)
        mu, logVar

    let sampleLatent mu (logVar:Tensor) =
        let std = dsharp.exp(0.5*logVar)
        let eps = dsharp.randnLike(std)
        eps.mul(std).add(mu)

    let decode z =
        let mutable h = z
        for i in 0..dec.Length-2 do
            h <- activation <| dec.[i].forward(h)
        activationLast <| dec.[dec.Length-1].forward(h)

    /// <summary>TBD</summary>
    member _.encodeDecode(x:Tensor) =
        let batchSize = x.shape.[0]
        let mu, logVar = encode (x.view([batchSize; xDim]))
        let z = sampleLatent mu logVar
        decode z, mu, logVar

    /// <summary>TBD</summary>
    override m.forward(x) =
        let x, _, _ = m.encodeDecode(x) in x

    /// <summary>TBD</summary>
    override _.ToString() = sprintf "VAE(%A, %A, %A)" xDim hDims zDim

    /// <summary>TBD</summary>
    static member loss(xRecon:Tensor, x:Tensor, mu:Tensor, logVar:Tensor) =
        let bce = dsharp.bceLoss(xRecon, x.viewAs(xRecon), reduction="sum")
        let kl = -0.5 * dsharp.sum(1. + logVar - mu.pow(2.) - logVar.exp())
        bce + kl

    /// <summary>TBD</summary>
    member m.loss(x, ?normalize:bool) =
        let normalize = defaultArg normalize true
        let xRecon, mu, logVar = m.encodeDecode x
        let loss = VAE.loss(xRecon, x, mu, logVar)
        if normalize then loss / x.shape.[0] else loss

    /// <summary>TBD</summary>
    member _.sample(?numSamples:int) = 
        let numSamples = defaultArg numSamples 1
        dsharp.randn([|numSamples; zDim|]) |> decode