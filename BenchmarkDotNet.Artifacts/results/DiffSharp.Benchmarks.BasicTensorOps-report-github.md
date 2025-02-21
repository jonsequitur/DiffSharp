``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.630 (2004/?/20H1)
Intel Xeon CPU E5-1620 0 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]   : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT DEBUG
  ShortRun : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                           Method |   Categories | tensorSize | dtypeName | deviceName |             Mean |             Error |         StdDev | Ratio | RatioSD | Baseline |
|--------------------------------- |------------- |----------- |---------- |----------- |-----------------:|------------------:|---------------:|------:|--------:|--------- |
|              **fromCpuData_PyTorch** |  **fromCpuData** |         **16** |   **float32** |        **cpu** |    **579,160.63 μs** |     **81,747.970 μs** |   **4,480.882 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |         16 |   float32 |        cpu |    168,645.83 μs |     67,192.215 μs |   3,683.032 μs | 0.291 |    0.01 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |         16 |   float32 |        cpu |    252,326.83 μs |    193,413.315 μs |  10,601.636 μs | 0.436 |    0.02 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |         16 |   float32 |        cpu |    253,604.20 μs |     24,911.732 μs |   1,365.496 μs | 0.438 |    0.01 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |         16 |   float32 |        cpu |      4,974.57 μs |      3,368.535 μs |     184.641 μs | 0.009 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |         16 |   float32 |        cpu |      4,100.11 μs |      5,138.790 μs |     281.674 μs | 0.007 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |         16 |   float32 |        cpu |  1,634,240.47 μs |     91,045.102 μs |   4,990.489 μs | 1.000 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |         16 |   float32 |        cpu |    600,934.70 μs |    207,454.461 μs |  11,371.279 μs | 0.368 |    0.01 |       No |
|            zeros_RawTensor_Torch |        zeros |         16 |   float32 |        cpu |    695,440.47 μs |  1,186,096.594 μs |  65,013.957 μs | 0.426 |    0.04 |       No |
|               zeros_Tensor_Torch |        zeros |         16 |   float32 |        cpu |    807,213.23 μs |  2,191,448.616 μs | 120,120.693 μs | 0.494 |    0.07 |       No |
|        zeros_RawTensor_Reference |        zeros |         16 |   float32 |        cpu |     14,501.57 μs |      7,479.389 μs |     409.971 μs | 0.009 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |         16 |   float32 |        cpu |     13,288.82 μs |     15,172.047 μs |     831.631 μs | 0.008 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |         16 |   float32 |        cpu |  1,769,297.73 μs |    109,986.861 μs |   6,028.751 μs | 1.000 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |         16 |   float32 |        cpu |    621,308.37 μs |    207,002.948 μs |  11,346.530 μs | 0.351 |    0.01 |       No |
|             ones_RawTensor_Torch |         ones |         16 |   float32 |        cpu |    683,241.23 μs |    484,719.764 μs |  26,569.126 μs | 0.386 |    0.02 |       No |
|                ones_Tensor_Torch |         ones |         16 |   float32 |        cpu |    624,892.47 μs |     59,012.282 μs |   3,234.662 μs | 0.353 |    0.00 |       No |
|         ones_RawTensor_Reference |         ones |         16 |   float32 |        cpu |     13,926.15 μs |     10,708.472 μs |     586.967 μs | 0.008 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |         16 |   float32 |        cpu |     14,693.00 μs |     11,877.512 μs |     651.046 μs | 0.008 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |         16 |   float32 |        cpu |  1,872,806.37 μs |     87,736.457 μs |   4,809.131 μs |  1.00 |    0.00 |      Yes |
|                  rand_TorchSharp |         rand |         16 |   float32 |        cpu |    695,513.00 μs |    244,578.805 μs |  13,406.190 μs |  0.37 |    0.01 |       No |
|             rand_RawTensor_Torch |         rand |         16 |   float32 |        cpu |    772,815.43 μs |    350,898.386 μs |  19,233.925 μs |  0.41 |    0.01 |       No |
|                rand_Tensor_Torch |         rand |         16 |   float32 |        cpu |    758,911.23 μs |    210,089.033 μs |  11,515.689 μs |  0.41 |    0.01 |       No |
|         rand_RawTensor_Reference |         rand |         16 |   float32 |        cpu |     44,543.54 μs |      4,782.023 μs |     262.119 μs |  0.02 |    0.00 |       No |
|            rand_Tensor_Reference |         rand |         16 |   float32 |        cpu |     45,960.60 μs |      3,511.339 μs |     192.468 μs |  0.02 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |         16 |   float32 |        cpu |    759,420.37 μs |     93,252.172 μs |   5,111.466 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |         16 |   float32 |        cpu |    522,866.73 μs |    326,940.505 μs |  17,920.712 μs |  0.69 |    0.02 |       No |
|         addition_RawTensor_Torch |     addition |         16 |   float32 |        cpu |    591,389.37 μs |    222,591.732 μs |  12,201.004 μs |  0.78 |    0.01 |       No |
|            addition_Tensor_Torch |     addition |         16 |   float32 |        cpu |    886,741.57 μs |    174,678.104 μs |   9,574.696 μs |  1.17 |    0.02 |       No |
|     addition_RawTensor_Reference |     addition |         16 |   float32 |        cpu |     15,062.36 μs |      4,671.495 μs |     256.060 μs |  0.02 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |         16 |   float32 |        cpu |    105,412.77 μs |     21,041.385 μs |   1,153.349 μs |  0.14 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |         16 |   float32 |        cpu |  1,865,589.87 μs |     95,076.102 μs |   5,211.442 μs | 1.000 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |         16 |   float32 |        cpu |  1,534,195.30 μs |    595,306.423 μs |  32,630.754 μs | 0.822 |    0.02 |       No |
|        addScalar_RawTensor_Torch |    addScalar |         16 |   float32 |        cpu |  1,668,056.23 μs |    337,379.800 μs |  18,492.925 μs | 0.894 |    0.01 |       No |
|           addScalar_Tensor_Torch |    addScalar |         16 |   float32 |        cpu |  2,233,194.70 μs |    398,843.714 μs |  21,861.970 μs | 1.197 |    0.01 |       No |
|    addScalar_RawTensor_Reference |    addScalar |         16 |   float32 |        cpu |      7,341.36 μs |      3,870.993 μs |     212.182 μs | 0.004 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |         16 |   float32 |        cpu |    494,740.97 μs |    179,718.434 μs |   9,850.974 μs | 0.265 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |         16 |   float32 |        cpu |    908,490.23 μs |     12,999.047 μs |     712.522 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |         16 |   float32 |        cpu |    483,343.90 μs |    269,523.059 μs |  14,773.468 μs |  0.53 |    0.02 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |         16 |   float32 |        cpu |    621,793.07 μs |    648,674.353 μs |  35,556.030 μs |  0.68 |    0.04 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |         16 |   float32 |        cpu |  2,853,379.57 μs |    364,541.829 μs |  19,981.768 μs |  3.14 |    0.02 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |         16 |   float32 |        cpu |     16,329.43 μs |      8,867.206 μs |     486.041 μs |  0.02 |    0.00 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |         16 |   float32 |        cpu |    559,631.60 μs |    120,127.623 μs |   6,584.600 μs |  0.62 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |         16 |   float32 |        cpu |    410,515.27 μs |     10,489.082 μs |     574.942 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |         16 |   float32 |        cpu |    323,265.60 μs |    516,286.562 μs |  28,299.409 μs |  0.79 |    0.07 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |         16 |   float32 |        cpu |    329,980.73 μs |    183,425.475 μs |  10,054.169 μs |  0.80 |    0.02 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |         16 |   float32 |        cpu |    941,081.13 μs |  1,098,656.445 μs |  60,221.067 μs |  2.29 |    0.15 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |         16 |   float32 |        cpu |     15,050.05 μs |      2,637.449 μs |     144.567 μs |  0.04 |    0.00 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |         16 |   float32 |        cpu |    105,823.70 μs |     53,652.035 μs |   2,940.849 μs |  0.26 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |         16 |   float32 |        cpu |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |         16 |   float32 |        cpu |     55,157.93 μs |     12,084.756 μs |     662.406 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |         16 |   float32 |        cpu |     64,799.87 μs |     54,468.231 μs |   2,985.588 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |         16 |   float32 |        cpu |    100,802.50 μs |     39,722.876 μs |   2,177.345 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |         16 |   float32 |        cpu |     72,823.27 μs |    301,580.567 μs |  16,530.649 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |         16 |   float32 |        cpu |     62,734.65 μs |     11,178.256 μs |     612.718 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |         **16** |   **float32** |       **cuda** |  **3,550,143.17 μs** |    **133,064.697 μs** |   **7,293.725 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |         16 |   float32 |       cuda |    170,549.53 μs |    203,595.073 μs |  11,159.733 μs | 0.048 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |         16 |   float32 |       cuda |  2,552,076.03 μs |     94,904.657 μs |   5,202.044 μs | 0.719 |    0.00 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |         16 |   float32 |       cuda |  2,543,132.37 μs |     72,288.171 μs |   3,962.359 μs | 0.716 |    0.00 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |         16 |   float32 |       cuda |      2,043.32 μs |        610.269 μs |      33.451 μs | 0.001 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |         16 |   float32 |       cuda |      3,497.26 μs |        438.296 μs |      24.024 μs | 0.001 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |         16 |   float32 |       cuda |  5,450,922.23 μs |    111,926.118 μs |   6,135.048 μs | 1.000 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |         16 |   float32 |       cuda |  3,169,658.00 μs |    471,647.462 μs |  25,852.589 μs | 0.581 |    0.00 |       No |
|            zeros_RawTensor_Torch |        zeros |         16 |   float32 |       cuda |  3,291,795.17 μs |  1,238,659.382 μs |  67,895.100 μs | 0.604 |    0.01 |       No |
|               zeros_Tensor_Torch |        zeros |         16 |   float32 |       cuda |  3,354,469.73 μs |  5,413,896.490 μs | 296,753.935 μs | 0.615 |    0.05 |       No |
|        zeros_RawTensor_Reference |        zeros |         16 |   float32 |       cuda |     28,384.53 μs |    129,205.069 μs |   7,082.166 μs | 0.005 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |         16 |   float32 |       cuda |     36,284.63 μs |     50,259.532 μs |   2,754.895 μs | 0.007 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |         16 |   float32 |       cuda |  5,168,419.37 μs |     57,128.585 μs |   3,131.411 μs | 1.000 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |         16 |   float32 |       cuda |  2,925,068.30 μs |    615,611.428 μs |  33,743.740 μs | 0.566 |    0.01 |       No |
|             ones_RawTensor_Torch |         ones |         16 |   float32 |       cuda |  2,945,238.43 μs |  1,223,870.954 μs |  67,084.497 μs | 0.570 |    0.01 |       No |
|                ones_Tensor_Torch |         ones |         16 |   float32 |       cuda |  3,064,410.43 μs |  1,290,440.628 μs |  70,733.405 μs | 0.593 |    0.01 |       No |
|         ones_RawTensor_Reference |         ones |         16 |   float32 |       cuda |     14,359.23 μs |      1,993.925 μs |     109.294 μs | 0.003 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |         16 |   float32 |       cuda |     15,838.13 μs |      3,262.410 μs |     178.824 μs | 0.003 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |         16 |   float32 |       cuda |  5,619,854.73 μs |     51,871.662 μs |   2,843.261 μs | 1.000 |    0.00 |      Yes |
|                  rand_TorchSharp |         rand |         16 |   float32 |       cuda |  2,810,893.87 μs |    174,050.745 μs |   9,540.309 μs | 0.500 |    0.00 |       No |
|             rand_RawTensor_Torch |         rand |         16 |   float32 |       cuda |  3,108,389.33 μs |  3,038,840.213 μs | 166,569.086 μs | 0.553 |    0.03 |       No |
|                rand_Tensor_Torch |         rand |         16 |   float32 |       cuda |  3,039,212.10 μs |  1,404,873.137 μs |  77,005.837 μs | 0.541 |    0.01 |       No |
|         rand_RawTensor_Reference |         rand |         16 |   float32 |       cuda |     43,708.10 μs |      6,273.844 μs |     343.891 μs | 0.008 |    0.00 |       No |
|            rand_Tensor_Reference |         rand |         16 |   float32 |       cuda |     44,079.37 μs |     11,605.870 μs |     636.157 μs | 0.008 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |         16 |   float32 |       cuda |  3,480,323.13 μs |     57,930.633 μs |   3,175.373 μs | 1.000 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |         16 |   float32 |       cuda |  2,417,328.40 μs |  2,021,617.808 μs | 110,811.694 μs | 0.695 |    0.03 |       No |
|         addition_RawTensor_Torch |     addition |         16 |   float32 |       cuda |  2,533,644.40 μs |    190,467.400 μs |  10,440.161 μs | 0.728 |    0.00 |       No |
|            addition_Tensor_Torch |     addition |         16 |   float32 |       cuda |  3,198,687.73 μs |    465,337.575 μs |  25,506.723 μs | 0.919 |    0.01 |       No |
|     addition_RawTensor_Reference |     addition |         16 |   float32 |       cuda |     14,068.04 μs |      2,206.716 μs |     120.958 μs | 0.004 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |         16 |   float32 |       cuda |    100,606.03 μs |     29,309.022 μs |   1,606.526 μs | 0.029 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |         16 |   float32 |       cuda |  4,501,822.70 μs |     34,857.660 μs |   1,910.666 μs | 1.000 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |         16 |   float32 |       cuda |  3,460,468.07 μs |  1,980,183.517 μs | 108,540.540 μs | 0.769 |    0.02 |       No |
|        addScalar_RawTensor_Torch |    addScalar |         16 |   float32 |       cuda |  3,763,576.93 μs |  6,897,625.254 μs | 378,082.115 μs | 0.836 |    0.08 |       No |
|           addScalar_Tensor_Torch |    addScalar |         16 |   float32 |       cuda |  5,701,483.67 μs |  2,165,138.412 μs | 118,678.542 μs | 1.266 |    0.03 |       No |
|    addScalar_RawTensor_Reference |    addScalar |         16 |   float32 |       cuda |      7,860.50 μs |      5,183.554 μs |     284.128 μs | 0.002 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |         16 |   float32 |       cuda |    511,498.53 μs |    333,861.805 μs |  18,300.092 μs | 0.114 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |         16 |   float32 |       cuda |  3,641,616.03 μs |     74,227.579 μs |   4,068.664 μs | 1.000 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |         16 |   float32 |       cuda |  2,281,550.53 μs |    151,075.196 μs |   8,280.941 μs | 0.627 |    0.00 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |         16 |   float32 |       cuda |  2,631,259.60 μs |  1,235,460.412 μs |  67,719.754 μs | 0.723 |    0.02 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |         16 |   float32 |       cuda |  7,823,767.67 μs |  3,330,555.763 μs | 182,559.000 μs | 2.148 |    0.05 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |         16 |   float32 |       cuda |     16,097.62 μs |      2,029.301 μs |     111.233 μs | 0.004 |    0.00 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |         16 |   float32 |       cuda |    624,830.57 μs |     86,957.930 μs |   4,766.458 μs | 0.172 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |         16 |   float32 |       cuda |  1,776,202.07 μs |    111,758.771 μs |   6,125.875 μs | 1.000 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |         16 |   float32 |       cuda |  1,448,169.83 μs |    801,667.731 μs |  43,942.113 μs | 0.815 |    0.03 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |         16 |   float32 |       cuda |  1,486,880.10 μs |  1,241,919.505 μs |  68,073.799 μs | 0.837 |    0.04 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |         16 |   float32 |       cuda |  3,070,272.80 μs |    730,987.850 μs |  40,067.911 μs | 1.729 |    0.03 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |         16 |   float32 |       cuda |     15,042.95 μs |        476.679 μs |      26.128 μs | 0.008 |    0.00 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |         16 |   float32 |       cuda |    104,260.40 μs |     35,047.193 μs |   1,921.055 μs | 0.059 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |         16 |   float32 |       cuda |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |         16 |   float32 |       cuda |    337,118.80 μs |    589,182.854 μs |  32,295.100 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |         16 |   float32 |       cuda |    341,228.90 μs |    130,325.656 μs |   7,143.589 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |         16 |   float32 |       cuda |    402,428.23 μs |    190,492.377 μs |  10,441.530 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |         16 |   float32 |       cuda |     51,096.02 μs |     17,149.002 μs |     939.995 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |         16 |   float32 |       cuda |     63,365.81 μs |      9,116.401 μs |     499.701 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |         **16** |   **float64** |        **cpu** |    **543,629.93 μs** |     **46,580.032 μs** |   **2,553.209 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |         16 |   float64 |        cpu |    167,548.67 μs |    161,860.118 μs |   8,872.099 μs | 0.308 |    0.01 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |         16 |   float64 |        cpu |    278,198.43 μs |     54,100.236 μs |   2,965.417 μs | 0.512 |    0.01 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |         16 |   float64 |        cpu |    285,581.30 μs |    239,822.329 μs |  13,145.471 μs | 0.525 |    0.02 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |         16 |   float64 |        cpu |      2,071.70 μs |        312.191 μs |      17.112 μs | 0.004 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |         16 |   float64 |        cpu |      4,554.03 μs |        769.145 μs |      42.159 μs | 0.008 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |         16 |   float64 |        cpu |  1,682,826.33 μs |     73,303.506 μs |   4,018.012 μs | 1.000 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |         16 |   float64 |        cpu |    602,577.73 μs |     51,452.300 μs |   2,820.274 μs | 0.358 |    0.00 |       No |
|            zeros_RawTensor_Torch |        zeros |         16 |   float64 |        cpu |    637,921.53 μs |    244,661.551 μs |  13,410.725 μs | 0.379 |    0.01 |       No |
|               zeros_Tensor_Torch |        zeros |         16 |   float64 |        cpu |    671,795.83 μs |    567,091.603 μs |  31,084.204 μs | 0.399 |    0.02 |       No |
|        zeros_RawTensor_Reference |        zeros |         16 |   float64 |        cpu |     12,162.45 μs |      5,228.337 μs |     286.583 μs | 0.007 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |         16 |   float64 |        cpu |     13,734.90 μs |      3,382.668 μs |     185.415 μs | 0.008 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |         16 |   float64 |        cpu |  1,670,433.47 μs |     16,825.557 μs |     922.266 μs | 1.000 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |         16 |   float64 |        cpu |    590,454.87 μs |     56,926.040 μs |   3,120.308 μs | 0.353 |    0.00 |       No |
|             ones_RawTensor_Torch |         ones |         16 |   float64 |        cpu |    669,167.03 μs |    294,456.647 μs |  16,140.162 μs | 0.401 |    0.01 |       No |
|                ones_Tensor_Torch |         ones |         16 |   float64 |        cpu |    660,715.90 μs |    350,173.533 μs |  19,194.193 μs | 0.396 |    0.01 |       No |
|         ones_RawTensor_Reference |         ones |         16 |   float64 |        cpu |     14,405.01 μs |      3,694.028 μs |     202.482 μs | 0.009 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |         16 |   float64 |        cpu |     15,614.81 μs |      2,119.198 μs |     116.160 μs | 0.009 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |         16 |   float64 |        cpu |  1,938,709.80 μs |    108,723.945 μs |   5,959.526 μs |  1.00 |    0.00 |      Yes |
|                  rand_TorchSharp |         rand |         16 |   float64 |        cpu |    800,132.00 μs |    655,887.044 μs |  35,951.382 μs |  0.41 |    0.02 |       No |
|             rand_RawTensor_Torch |         rand |         16 |   float64 |        cpu |  1,035,337.00 μs |    192,539.627 μs |  10,553.747 μs |  0.53 |    0.01 |       No |
|                rand_Tensor_Torch |         rand |         16 |   float64 |        cpu |    922,615.80 μs |    355,297.242 μs |  19,475.041 μs |  0.48 |    0.01 |       No |
|         rand_RawTensor_Reference |         rand |         16 |   float64 |        cpu |     49,817.79 μs |     33,904.145 μs |   1,858.401 μs |  0.03 |    0.00 |       No |
|            rand_Tensor_Reference |         rand |         16 |   float64 |        cpu |     47,836.21 μs |     22,952.489 μs |   1,258.103 μs |  0.02 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |         16 |   float64 |        cpu |    759,279.47 μs |     59,894.960 μs |   3,283.045 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |         16 |   float64 |        cpu |    597,451.27 μs |    562,156.349 μs |  30,813.686 μs |  0.79 |    0.04 |       No |
|         addition_RawTensor_Torch |     addition |         16 |   float64 |        cpu |    767,794.77 μs |    595,035.187 μs |  32,615.886 μs |  1.01 |    0.04 |       No |
|            addition_Tensor_Torch |     addition |         16 |   float64 |        cpu |  1,055,813.23 μs |  1,500,695.324 μs |  82,258.175 μs |  1.39 |    0.10 |       No |
|     addition_RawTensor_Reference |     addition |         16 |   float64 |        cpu |     14,586.62 μs |      7,885.940 μs |     432.255 μs |  0.02 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |         16 |   float64 |        cpu |    103,505.83 μs |     55,665.708 μs |   3,051.225 μs |  0.14 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |         16 |   float64 |        cpu |  1,923,168.23 μs |     86,618.199 μs |   4,747.836 μs | 1.000 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |         16 |   float64 |        cpu |  1,515,990.80 μs |    267,944.444 μs |  14,686.939 μs | 0.788 |    0.01 |       No |
|        addScalar_RawTensor_Torch |    addScalar |         16 |   float64 |        cpu |  1,780,296.40 μs |    743,187.256 μs |  40,736.601 μs | 0.926 |    0.02 |       No |
|           addScalar_Tensor_Torch |    addScalar |         16 |   float64 |        cpu |  2,288,845.53 μs |    769,399.428 μs |  42,173.379 μs | 1.190 |    0.02 |       No |
|    addScalar_RawTensor_Reference |    addScalar |         16 |   float64 |        cpu |      7,629.81 μs |      7,318.628 μs |     401.159 μs | 0.004 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |         16 |   float64 |        cpu |    511,264.30 μs |    602,427.294 μs |  33,021.073 μs | 0.266 |    0.02 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |         16 |   float64 |        cpu |    903,604.50 μs |     79,858.632 μs |   4,377.321 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |         16 |   float64 |        cpu |    545,445.57 μs |    289,284.595 μs |  15,856.665 μs |  0.60 |    0.02 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |         16 |   float64 |        cpu |    643,504.77 μs |    941,247.000 μs |  51,592.924 μs |  0.71 |    0.06 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |         16 |   float64 |        cpu |  2,934,091.57 μs |    214,749.572 μs |  11,771.149 μs |  3.25 |    0.03 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |         16 |   float64 |        cpu |     15,718.86 μs |      1,867.780 μs |     102.379 μs |  0.02 |    0.00 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |         16 |   float64 |        cpu |    586,475.03 μs |    436,217.315 μs |  23,910.543 μs |  0.65 |    0.03 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |         16 |   float64 |        cpu |    399,131.83 μs |     88,151.419 μs |   4,831.877 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |         16 |   float64 |        cpu |    330,147.30 μs |    211,959.581 μs |  11,618.220 μs |  0.83 |    0.02 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |         16 |   float64 |        cpu |    347,608.77 μs |     36,650.571 μs |   2,008.941 μs |  0.87 |    0.01 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |         16 |   float64 |        cpu |    918,165.83 μs |    323,700.843 μs |  17,743.136 μs |  2.30 |    0.02 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |         16 |   float64 |        cpu |     16,025.44 μs |      1,642.614 μs |      90.037 μs |  0.04 |    0.00 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |         16 |   float64 |        cpu |     99,766.00 μs |     32,735.839 μs |   1,794.362 μs |  0.25 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |         16 |   float64 |        cpu |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |         16 |   float64 |        cpu |     58,240.73 μs |      8,816.987 μs |     483.289 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |         16 |   float64 |        cpu |     81,439.35 μs |    244,851.534 μs |  13,421.139 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |         16 |   float64 |        cpu |     96,784.40 μs |     52,893.053 μs |   2,899.247 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |         16 |   float64 |        cpu |     73,171.93 μs |    101,565.557 μs |   5,567.151 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |         16 |   float64 |        cpu |     66,019.33 μs |     65,516.102 μs |   3,591.159 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |         **16** |   **float64** |       **cuda** |  **3,570,861.60 μs** |     **86,030.743 μs** |   **4,715.635 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |         16 |   float64 |       cuda |    190,039.30 μs |    439,871.770 μs |  24,110.856 μs | 0.053 |    0.01 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |         16 |   float64 |       cuda |  2,570,080.20 μs |    245,709.698 μs |  13,468.178 μs | 0.720 |    0.00 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |         16 |   float64 |       cuda |  2,972,276.80 μs |  8,293,152.433 μs | 454,575.669 μs | 0.832 |    0.13 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |         16 |   float64 |       cuda |      2,115.84 μs |        374.363 μs |      20.520 μs | 0.001 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |         16 |   float64 |       cuda |      4,511.85 μs |      3,292.567 μs |     180.477 μs | 0.001 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |         16 |   float64 |       cuda |  5,252,645.13 μs |     28,109.103 μs |   1,540.755 μs | 1.000 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |         16 |   float64 |       cuda |  2,815,450.47 μs |  1,905,496.312 μs | 104,446.683 μs | 0.536 |    0.02 |       No |
|            zeros_RawTensor_Torch |        zeros |         16 |   float64 |       cuda |  2,965,395.33 μs |    864,474.882 μs |  47,384.785 μs | 0.565 |    0.01 |       No |
|               zeros_Tensor_Torch |        zeros |         16 |   float64 |       cuda |  3,025,355.30 μs |  1,254,310.612 μs |  68,752.997 μs | 0.576 |    0.01 |       No |
|        zeros_RawTensor_Reference |        zeros |         16 |   float64 |       cuda |     12,782.43 μs |     12,074.086 μs |     661.821 μs | 0.002 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |         16 |   float64 |       cuda |     13,366.05 μs |      4,880.705 μs |     267.528 μs | 0.003 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |         16 |   float64 |       cuda |  5,099,987.47 μs |     35,318.999 μs |   1,935.953 μs | 1.000 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |         16 |   float64 |       cuda |  2,682,871.27 μs |    436,740.732 μs |  23,939.233 μs | 0.526 |    0.00 |       No |
|             ones_RawTensor_Torch |         ones |         16 |   float64 |       cuda |  2,829,827.33 μs |  1,239,577.454 μs |  67,945.423 μs | 0.555 |    0.01 |       No |
|                ones_Tensor_Torch |         ones |         16 |   float64 |       cuda |  3,939,002.23 μs | 13,288,272.359 μs | 728,375.047 μs | 0.772 |    0.14 |       No |
|         ones_RawTensor_Reference |         ones |         16 |   float64 |       cuda |     14,944.91 μs |     14,641.531 μs |     802.552 μs | 0.003 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |         16 |   float64 |       cuda |     14,323.89 μs |      6,478.450 μs |     355.106 μs | 0.003 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |         16 |   float64 |       cuda |  5,469,625.73 μs |    178,863.841 μs |   9,804.131 μs | 1.000 |    0.00 |      Yes |
|                  rand_TorchSharp |         rand |         16 |   float64 |       cuda |  2,815,622.97 μs |    365,920.884 μs |  20,057.358 μs | 0.515 |    0.00 |       No |
|             rand_RawTensor_Torch |         rand |         16 |   float64 |       cuda |  3,114,994.97 μs |    216,794.293 μs |  11,883.227 μs | 0.570 |    0.00 |       No |
|                rand_Tensor_Torch |         rand |         16 |   float64 |       cuda |  3,054,200.87 μs |    292,733.237 μs |  16,045.697 μs | 0.558 |    0.00 |       No |
|         rand_RawTensor_Reference |         rand |         16 |   float64 |       cuda |     44,851.47 μs |      5,185.902 μs |     284.257 μs | 0.008 |    0.00 |       No |
|            rand_Tensor_Reference |         rand |         16 |   float64 |       cuda |     46,236.37 μs |     13,417.130 μs |     735.438 μs | 0.008 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |         16 |   float64 |       cuda |  3,190,404.67 μs |     50,999.973 μs |   2,795.481 μs | 1.000 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |         16 |   float64 |       cuda |  2,418,307.73 μs |  1,016,379.483 μs |  55,711.189 μs | 0.758 |    0.02 |       No |
|         addition_RawTensor_Torch |     addition |         16 |   float64 |       cuda |  2,525,079.80 μs |    489,699.338 μs |  26,842.073 μs | 0.791 |    0.01 |       No |
|            addition_Tensor_Torch |     addition |         16 |   float64 |       cuda |  3,272,176.50 μs |    899,867.004 μs |  49,324.747 μs | 1.026 |    0.01 |       No |
|     addition_RawTensor_Reference |     addition |         16 |   float64 |       cuda |     13,409.03 μs |      9,959.641 μs |     545.922 μs | 0.004 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |         16 |   float64 |       cuda |    105,866.63 μs |     97,371.794 μs |   5,337.277 μs | 0.033 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |         16 |   float64 |       cuda |  4,462,889.67 μs |     25,556.405 μs |   1,400.833 μs | 1.000 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |         16 |   float64 |       cuda |  3,252,196.77 μs |    851,510.026 μs |  46,674.138 μs | 0.729 |    0.01 |       No |
|        addScalar_RawTensor_Torch |    addScalar |         16 |   float64 |       cuda |  3,524,507.87 μs |    225,262.261 μs |  12,347.385 μs | 0.790 |    0.00 |       No |
|           addScalar_Tensor_Torch |    addScalar |         16 |   float64 |       cuda |  5,712,205.70 μs |  1,084,979.895 μs |  59,471.409 μs | 1.280 |    0.01 |       No |
|    addScalar_RawTensor_Reference |    addScalar |         16 |   float64 |       cuda |      7,573.11 μs |      1,907.489 μs |     104.556 μs | 0.002 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |         16 |   float64 |       cuda |    481,925.27 μs |    112,632.103 μs |   6,173.746 μs | 0.108 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |         16 |   float64 |       cuda |  3,715,489.33 μs |    100,051.984 μs |   5,484.187 μs | 1.000 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |         16 |   float64 |       cuda |  2,341,045.10 μs |    229,966.995 μs |  12,605.267 μs | 0.630 |    0.00 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |         16 |   float64 |       cuda |  2,709,749.30 μs |  1,523,944.596 μs |  83,532.546 μs | 0.729 |    0.02 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |         16 |   float64 |       cuda |  7,637,044.53 μs |  2,859,142.570 μs | 156,719.252 μs | 2.055 |    0.04 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |         16 |   float64 |       cuda |     14,759.37 μs |        884.773 μs |      48.497 μs | 0.004 |    0.00 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |         16 |   float64 |       cuda |    574,032.70 μs |    132,582.650 μs |   7,267.302 μs | 0.154 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |         16 |   float64 |       cuda |  1,804,741.40 μs |     70,546.989 μs |   3,866.919 μs | 1.000 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |         16 |   float64 |       cuda |  1,584,026.57 μs |    195,989.197 μs |  10,742.829 μs | 0.878 |    0.01 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |         16 |   float64 |       cuda |  1,571,154.77 μs |  2,416,877.998 μs | 132,477.238 μs | 0.870 |    0.07 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |         16 |   float64 |       cuda |  3,379,017.00 μs |  2,319,831.550 μs | 127,157.795 μs | 1.872 |    0.07 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |         16 |   float64 |       cuda |     16,215.35 μs |      2,439.860 μs |     133.737 μs | 0.009 |    0.00 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |         16 |   float64 |       cuda |     99,608.43 μs |     14,074.784 μs |     771.486 μs | 0.055 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |         16 |   float64 |       cuda |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |         16 |   float64 |       cuda |    293,726.63 μs |    755,555.167 μs |  41,414.528 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |         16 |   float64 |       cuda |    300,118.30 μs |    101,934.699 μs |   5,587.385 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |         16 |   float64 |       cuda |    364,062.40 μs |    127,673.214 μs |   6,998.200 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |         16 |   float64 |       cuda |     51,524.00 μs |     39,967.313 μs |   2,190.743 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |         16 |   float64 |       cuda |     63,112.16 μs |     29,022.495 μs |   1,590.821 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |         **16** |     **int32** |        **cpu** |    **525,054.13 μs** |    **112,010.822 μs** |   **6,139.691 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |         16 |     int32 |        cpu |    170,301.23 μs |    139,202.939 μs |   7,630.183 μs | 0.324 |    0.02 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |         16 |     int32 |        cpu |    244,412.93 μs |    139,900.365 μs |   7,668.411 μs | 0.465 |    0.01 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |         16 |     int32 |        cpu |    256,017.90 μs |    262,980.398 μs |  14,414.843 μs | 0.488 |    0.02 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |         16 |     int32 |        cpu |      1,983.82 μs |         31.754 μs |       1.741 μs | 0.004 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |         16 |     int32 |        cpu |      2,598.42 μs |      1,056.206 μs |      57.894 μs | 0.005 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |         16 |     int32 |        cpu |  1,659,727.70 μs |     82,715.897 μs |   4,533.937 μs | 1.000 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |         16 |     int32 |        cpu |    548,743.80 μs |    306,242.001 μs |  16,786.157 μs | 0.331 |    0.01 |       No |
|            zeros_RawTensor_Torch |        zeros |         16 |     int32 |        cpu |    597,605.47 μs |     56,097.904 μs |   3,074.915 μs | 0.360 |    0.00 |       No |
|               zeros_Tensor_Torch |        zeros |         16 |     int32 |        cpu |    663,853.27 μs |    266,799.017 μs |  14,624.154 μs | 0.400 |    0.01 |       No |
|        zeros_RawTensor_Reference |        zeros |         16 |     int32 |        cpu |     10,613.56 μs |        245.717 μs |      13.469 μs | 0.006 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |         16 |     int32 |        cpu |     12,238.28 μs |      1,317.207 μs |      72.201 μs | 0.007 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |         16 |     int32 |        cpu |  1,642,693.00 μs |    100,013.934 μs |   5,482.101 μs | 1.000 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |         16 |     int32 |        cpu |    557,002.73 μs |     40,956.142 μs |   2,244.944 μs | 0.339 |    0.00 |       No |
|             ones_RawTensor_Torch |         ones |         16 |     int32 |        cpu |    592,034.00 μs |     68,635.938 μs |   3,762.167 μs | 0.360 |    0.00 |       No |
|                ones_Tensor_Torch |         ones |         16 |     int32 |        cpu |    626,426.93 μs |    477,981.567 μs |  26,199.783 μs | 0.381 |    0.02 |       No |
|         ones_RawTensor_Reference |         ones |         16 |     int32 |        cpu |     11,754.27 μs |      1,111.492 μs |      60.925 μs | 0.007 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |         16 |     int32 |        cpu |     13,392.57 μs |      1,407.781 μs |      77.165 μs | 0.008 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |         16 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |      Yes |
|                  rand_TorchSharp |         rand |         16 |     int32 |        cpu |    662,662.70 μs |    238,371.348 μs |  13,065.938 μs |     ? |       ? |       No |
|             rand_RawTensor_Torch |         rand |         16 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |       No |
|                rand_Tensor_Torch |         rand |         16 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |       No |
|         rand_RawTensor_Reference |         rand |         16 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |       No |
|            rand_Tensor_Reference |         rand |         16 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |         16 |     int32 |        cpu |    734,018.00 μs |    104,685.380 μs |   5,738.159 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |         16 |     int32 |        cpu |    501,801.80 μs |    203,276.181 μs |  11,142.253 μs |  0.68 |    0.02 |       No |
|         addition_RawTensor_Torch |     addition |         16 |     int32 |        cpu |    589,192.27 μs |    585,164.144 μs |  32,074.821 μs |  0.80 |    0.05 |       No |
|            addition_Tensor_Torch |     addition |         16 |     int32 |        cpu |    904,274.10 μs |    409,725.832 μs |  22,458.455 μs |  1.23 |    0.04 |       No |
|     addition_RawTensor_Reference |     addition |         16 |     int32 |        cpu |     12,215.54 μs |        374.471 μs |      20.526 μs |  0.02 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |         16 |     int32 |        cpu |    117,725.47 μs |    244,865.346 μs |  13,421.896 μs |  0.16 |    0.02 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |         16 |     int32 |        cpu |  1,935,625.20 μs |     54,831.509 μs |   3,005.500 μs | 1.000 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |         16 |     int32 |        cpu |  1,478,880.30 μs |     63,554.591 μs |   3,483.642 μs | 0.764 |    0.00 |       No |
|        addScalar_RawTensor_Torch |    addScalar |         16 |     int32 |        cpu |  1,635,236.37 μs |    147,200.821 μs |   8,068.574 μs | 0.845 |    0.00 |       No |
|           addScalar_Tensor_Torch |    addScalar |         16 |     int32 |        cpu |  3,575,709.20 μs |    400,105.034 μs |  21,931.107 μs | 1.847 |    0.01 |       No |
|    addScalar_RawTensor_Reference |    addScalar |         16 |     int32 |        cpu |      6,679.75 μs |        981.342 μs |      53.791 μs | 0.003 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |         16 |     int32 |        cpu |  3,965,901.73 μs |    421,665.322 μs |  23,112.899 μs | 2.049 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |         16 |     int32 |        cpu |    886,348.93 μs |    102,179.762 μs |   5,600.818 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |         16 |     int32 |        cpu |    470,757.03 μs |    119,179.564 μs |   6,532.634 μs |  0.53 |    0.00 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |         16 |     int32 |        cpu |    600,097.47 μs |    299,152.087 μs |  16,397.535 μs |  0.68 |    0.02 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |         16 |     int32 |        cpu |  3,018,068.63 μs |  4,871,180.566 μs | 267,005.844 μs |  3.41 |    0.32 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |         16 |     int32 |        cpu |     17,690.14 μs |     22,696.341 μs |   1,244.063 μs |  0.02 |    0.00 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |         16 |     int32 |        cpu |  7,961,474.20 μs |  3,079,353.122 μs | 168,789.735 μs |  8.98 |    0.22 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |         16 |     int32 |        cpu |    394,539.10 μs |     39,208.040 μs |   2,149.125 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |         16 |     int32 |        cpu |    279,782.23 μs |    109,448.299 μs |   5,999.231 μs |  0.71 |    0.02 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |         16 |     int32 |        cpu |    358,080.03 μs |    243,558.462 μs |  13,350.261 μs |  0.91 |    0.04 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |         16 |     int32 |        cpu |    937,359.47 μs |    446,416.906 μs |  24,469.617 μs |  2.38 |    0.05 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |         16 |     int32 |        cpu |     15,206.71 μs |      4,164.900 μs |     228.292 μs |  0.04 |    0.00 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |         16 |     int32 |        cpu |    105,927.40 μs |    147,694.396 μs |   8,095.628 μs |  0.27 |    0.02 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |         16 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |         16 |     int32 |        cpu |     49,449.33 μs |     19,631.590 μs |   1,076.074 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |         16 |     int32 |        cpu |     59,152.52 μs |     43,061.922 μs |   2,360.369 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |         16 |     int32 |        cpu |     95,939.77 μs |     82,165.231 μs |   4,503.754 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |         16 |     int32 |        cpu |     56,623.62 μs |     23,002.156 μs |   1,260.826 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |         16 |     int32 |        cpu |     72,087.93 μs |     94,010.084 μs |   5,153.010 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |         **16** |     **int32** |       **cuda** |  **3,379,083.37 μs** |     **75,412.875 μs** |   **4,133.634 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |         16 |     int32 |       cuda |    169,567.07 μs |    160,082.965 μs |   8,774.687 μs | 0.050 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |         16 |     int32 |       cuda |  2,969,835.20 μs |  4,746,562.245 μs | 260,175.093 μs | 0.879 |    0.08 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |         16 |     int32 |       cuda |  2,714,232.73 μs |  2,029,136.810 μs | 111,223.836 μs | 0.803 |    0.03 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |         16 |     int32 |       cuda |      4,578.37 μs |      1,355.559 μs |      74.303 μs | 0.001 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |         16 |     int32 |       cuda |      2,606.63 μs |        418.084 μs |      22.917 μs | 0.001 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |         16 |     int32 |       cuda |  5,136,123.33 μs |     72,369.759 μs |   3,966.831 μs | 1.000 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |         16 |     int32 |       cuda |  2,802,601.87 μs |  1,987,940.176 μs | 108,965.709 μs | 0.546 |    0.02 |       No |
|            zeros_RawTensor_Torch |        zeros |         16 |     int32 |       cuda |  2,944,293.47 μs |  1,288,344.803 μs |  70,618.526 μs | 0.573 |    0.01 |       No |
|               zeros_Tensor_Torch |        zeros |         16 |     int32 |       cuda |  2,866,336.27 μs |    551,116.351 μs |  30,208.547 μs | 0.558 |    0.01 |       No |
|        zeros_RawTensor_Reference |        zeros |         16 |     int32 |       cuda |     11,559.60 μs |      4,991.703 μs |     273.612 μs | 0.002 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |         16 |     int32 |       cuda |     13,094.34 μs |      1,585.789 μs |      86.922 μs | 0.003 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |         16 |     int32 |       cuda |  4,965,773.17 μs |    114,728.295 μs |   6,288.645 μs | 1.000 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |         16 |     int32 |       cuda |  2,843,417.00 μs |  3,272,204.919 μs | 179,360.593 μs | 0.573 |    0.04 |       No |
|             ones_RawTensor_Torch |         ones |         16 |     int32 |       cuda |  2,914,634.80 μs |  1,749,446.160 μs |  95,893.047 μs | 0.587 |    0.02 |       No |
|                ones_Tensor_Torch |         ones |         16 |     int32 |       cuda |  2,907,029.03 μs |    659,986.416 μs |  36,176.082 μs | 0.585 |    0.01 |       No |
|         ones_RawTensor_Reference |         ones |         16 |     int32 |       cuda |     14,323.59 μs |      6,738.908 μs |     369.382 μs | 0.003 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |         16 |     int32 |       cuda |     14,250.56 μs |     12,240.653 μs |     670.951 μs | 0.003 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |         16 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |      Yes |
|                  rand_TorchSharp |         rand |         16 |     int32 |       cuda |  2,917,649.40 μs |  1,184,908.624 μs |  64,948.840 μs |     ? |       ? |       No |
|             rand_RawTensor_Torch |         rand |         16 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|                rand_Tensor_Torch |         rand |         16 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|         rand_RawTensor_Reference |         rand |         16 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|            rand_Tensor_Reference |         rand |         16 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |         16 |     int32 |       cuda |  3,075,075.03 μs |     91,458.055 μs |   5,013.125 μs | 1.000 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |         16 |     int32 |       cuda |  2,423,198.17 μs |    797,924.448 μs |  43,736.931 μs | 0.788 |    0.02 |       No |
|         addition_RawTensor_Torch |     addition |         16 |     int32 |       cuda |  2,589,076.77 μs |    891,424.945 μs |  48,862.009 μs | 0.842 |    0.02 |       No |
|            addition_Tensor_Torch |     addition |         16 |     int32 |       cuda |  3,135,546.27 μs |  2,026,442.946 μs | 111,076.176 μs | 1.020 |    0.04 |       No |
|     addition_RawTensor_Reference |     addition |         16 |     int32 |       cuda |     12,794.40 μs |        635.354 μs |      34.826 μs | 0.004 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |         16 |     int32 |       cuda |    118,235.13 μs |     40,619.232 μs |   2,226.477 μs | 0.038 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |         16 |     int32 |       cuda |  4,241,064.37 μs |    132,524.876 μs |   7,264.136 μs | 1.000 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |         16 |     int32 |       cuda |  3,263,878.60 μs |    280,919.721 μs |  15,398.158 μs | 0.770 |    0.00 |       No |
|        addScalar_RawTensor_Torch |    addScalar |         16 |     int32 |       cuda |  3,542,710.47 μs |  1,107,569.202 μs |  60,709.605 μs | 0.835 |    0.01 |       No |
|           addScalar_Tensor_Torch |    addScalar |         16 |     int32 |       cuda | 10,230,795.13 μs |  6,101,489.563 μs | 334,443.232 μs | 2.412 |    0.07 |       No |
|    addScalar_RawTensor_Reference |    addScalar |         16 |     int32 |       cuda |      6,811.99 μs |      2,279.289 μs |     124.936 μs | 0.002 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |         16 |     int32 |       cuda |  4,026,414.70 μs |  1,706,992.402 μs |  93,566.014 μs | 0.949 |    0.02 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |         16 |     int32 |       cuda |  3,663,803.30 μs |     15,030.872 μs |     823.893 μs | 1.000 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |         16 |     int32 |       cuda |  2,312,553.53 μs |    949,799.752 μs |  52,061.729 μs | 0.631 |    0.01 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |         16 |     int32 |       cuda |  2,620,459.23 μs |  1,226,309.083 μs |  67,218.139 μs | 0.715 |    0.02 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |         16 |     int32 |       cuda |  7,226,935.03 μs |  1,426,429.741 μs |  78,187.427 μs | 1.973 |    0.02 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |         16 |     int32 |       cuda |     14,641.94 μs |     11,166.143 μs |     612.054 μs | 0.004 |    0.00 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |         16 |     int32 |       cuda |  7,677,065.13 μs |  1,964,208.699 μs | 107,664.907 μs | 2.095 |    0.03 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |         16 |     int32 |       cuda |  1,706,688.97 μs |     13,258.775 μs |     726.758 μs | 1.000 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |         16 |     int32 |       cuda |  1,446,319.33 μs |    742,089.204 μs |  40,676.413 μs | 0.847 |    0.02 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |         16 |     int32 |       cuda |  1,559,776.47 μs |  2,061,741.505 μs | 113,011.009 μs | 0.914 |    0.07 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |         16 |     int32 |       cuda |  3,103,571.70 μs |    940,987.440 μs |  51,578.697 μs | 1.818 |    0.03 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |         16 |     int32 |       cuda |     14,672.81 μs |      4,521.175 μs |     247.821 μs | 0.009 |    0.00 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |         16 |     int32 |       cuda |    118,716.33 μs |     53,948.561 μs |   2,957.103 μs | 0.070 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |         16 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |         16 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |         16 |     int32 |       cuda |  1,738,198.67 μs |    428,351.311 μs |  23,479.381 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |         16 |     int32 |       cuda |  1,873,786.37 μs |    438,609.620 μs |  24,041.673 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |         16 |     int32 |       cuda |     52,222.26 μs |      9,890.604 μs |     542.137 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |         16 |     int32 |       cuda |     64,310.71 μs |     12,843.786 μs |     704.011 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |       **2048** |   **float32** |        **cpu** |     **31,824.63 μs** |      **1,781.428 μs** |      **97.646 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |       2048 |   float32 |        cpu |      1,613.97 μs |        573.621 μs |      31.442 μs | 0.051 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |       2048 |   float32 |        cpu |      3,828.96 μs |        749.416 μs |      41.078 μs | 0.120 |    0.00 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |       2048 |   float32 |        cpu |      3,965.75 μs |        440.945 μs |      24.170 μs | 0.125 |    0.00 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |       2048 |   float32 |        cpu |        154.91 μs |         68.040 μs |       3.729 μs | 0.005 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |       2048 |   float32 |        cpu |        170.43 μs |         48.036 μs |       2.633 μs | 0.005 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |       2048 |   float32 |        cpu |     17,153.19 μs |      4,423.502 μs |     242.467 μs |  1.00 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |       2048 |   float32 |        cpu |     18,092.83 μs |      1,718.490 μs |      94.196 μs |  1.05 |    0.02 |       No |
|            zeros_RawTensor_Torch |        zeros |       2048 |   float32 |        cpu |     10,484.81 μs |      4,369.668 μs |     239.516 μs |  0.61 |    0.02 |       No |
|               zeros_Tensor_Torch |        zeros |       2048 |   float32 |        cpu |     10,594.34 μs |      5,977.569 μs |     327.651 μs |  0.62 |    0.03 |       No |
|        zeros_RawTensor_Reference |        zeros |       2048 |   float32 |        cpu |      1,085.92 μs |        191.461 μs |      10.495 μs |  0.06 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |       2048 |   float32 |        cpu |      1,082.40 μs |        355.746 μs |      19.500 μs |  0.06 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |       2048 |   float32 |        cpu |     16,066.08 μs |      4,165.591 μs |     228.330 μs |  1.00 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |       2048 |   float32 |        cpu |     18,238.30 μs |     14,503.880 μs |     795.007 μs |  1.14 |    0.05 |       No |
|             ones_RawTensor_Torch |         ones |       2048 |   float32 |        cpu |     10,622.53 μs |      1,893.666 μs |     103.798 μs |  0.66 |    0.01 |       No |
|                ones_Tensor_Torch |         ones |       2048 |   float32 |        cpu |     10,231.32 μs |      5,636.678 μs |     308.965 μs |  0.64 |    0.03 |       No |
|         ones_RawTensor_Reference |         ones |       2048 |   float32 |        cpu |      2,556.18 μs |        396.165 μs |      21.715 μs |  0.16 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |       2048 |   float32 |        cpu |      2,555.00 μs |        725.590 μs |      39.772 μs |  0.16 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |       2048 |   float32 |        cpu |     46,916.99 μs |      2,662.312 μs |     145.930 μs |  1.00 |    0.00 |      Yes |
|                  rand_TorchSharp |         rand |       2048 |   float32 |        cpu |     54,257.21 μs |     22,106.886 μs |   1,211.753 μs |  1.16 |    0.03 |       No |
|             rand_RawTensor_Torch |         rand |       2048 |   float32 |        cpu |     29,125.60 μs |     33,085.144 μs |   1,813.508 μs |  0.62 |    0.04 |       No |
|                rand_Tensor_Torch |         rand |       2048 |   float32 |        cpu |     28,297.22 μs |      4,894.127 μs |     268.264 μs |  0.60 |    0.00 |       No |
|         rand_RawTensor_Reference |         rand |       2048 |   float32 |        cpu |     32,758.74 μs |      4,753.894 μs |     260.577 μs |  0.70 |    0.01 |       No |
|            rand_Tensor_Reference |         rand |       2048 |   float32 |        cpu |     33,671.87 μs |      5,942.871 μs |     325.749 μs |  0.72 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |       2048 |   float32 |        cpu |     15,919.96 μs |      1,083.894 μs |      59.412 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |       2048 |   float32 |        cpu |     12,394.90 μs |      4,940.766 μs |     270.820 μs |  0.78 |    0.02 |       No |
|         addition_RawTensor_Torch |     addition |       2048 |   float32 |        cpu |     11,249.35 μs |      8,509.273 μs |     466.422 μs |  0.71 |    0.03 |       No |
|            addition_Tensor_Torch |     addition |       2048 |   float32 |        cpu |     14,138.90 μs |      5,955.208 μs |     326.425 μs |  0.89 |    0.02 |       No |
|     addition_RawTensor_Reference |     addition |       2048 |   float32 |        cpu |      7,947.46 μs |        376.176 μs |      20.619 μs |  0.50 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |       2048 |   float32 |        cpu |      8,068.75 μs |        896.173 μs |      49.122 μs |  0.51 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |       2048 |   float32 |        cpu |     31,832.29 μs |      2,388.465 μs |     130.920 μs |  1.00 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |       2048 |   float32 |        cpu |     20,986.10 μs |      5,380.076 μs |     294.900 μs |  0.66 |    0.01 |       No |
|        addScalar_RawTensor_Torch |    addScalar |       2048 |   float32 |        cpu |     22,238.21 μs |     12,403.152 μs |     679.859 μs |  0.70 |    0.02 |       No |
|           addScalar_Tensor_Torch |    addScalar |       2048 |   float32 |        cpu |     25,825.69 μs |     11,725.406 μs |     642.709 μs |  0.81 |    0.02 |       No |
|    addScalar_RawTensor_Reference |    addScalar |       2048 |   float32 |        cpu |      2,556.86 μs |      1,135.467 μs |      62.239 μs |  0.08 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |       2048 |   float32 |        cpu |     13,485.16 μs |      4,422.412 μs |     242.407 μs |  0.42 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |       2048 |   float32 |        cpu |     15,880.13 μs |      1,483.115 μs |      81.295 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |       2048 |   float32 |        cpu |     12,452.59 μs |      3,401.237 μs |     186.433 μs |  0.78 |    0.01 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |       2048 |   float32 |        cpu |     12,206.44 μs |      6,448.043 μs |     353.439 μs |  0.77 |    0.02 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |       2048 |   float32 |        cpu |     41,817.13 μs |     13,914.631 μs |     762.708 μs |  2.63 |    0.05 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |       2048 |   float32 |        cpu |      8,058.33 μs |      3,952.871 μs |     216.670 μs |  0.51 |    0.01 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |       2048 |   float32 |        cpu |     21,306.88 μs |      5,888.268 μs |     322.756 μs |  1.34 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |       2048 |   float32 |        cpu |     15,894.22 μs |      1,545.751 μs |      84.728 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |       2048 |   float32 |        cpu |      4,634.32 μs |      1,261.282 μs |      69.135 μs |  0.29 |    0.01 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |       2048 |   float32 |        cpu |      5,066.99 μs |        765.029 μs |      41.934 μs |  0.32 |    0.00 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |       2048 |   float32 |        cpu |     14,063.87 μs |        878.679 μs |      48.163 μs |  0.88 |    0.00 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |       2048 |   float32 |        cpu |      6,338.44 μs |        429.500 μs |      23.542 μs |  0.40 |    0.00 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |       2048 |   float32 |        cpu |      8,194.33 μs |      2,274.380 μs |     124.666 μs |  0.52 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |       2048 |   float32 |        cpu |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |       2048 |   float32 |        cpu |      2,840.03 μs |      5,068.734 μs |     277.834 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |       2048 |   float32 |        cpu |      2,921.96 μs |      1,486.218 μs |      81.465 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |       2048 |   float32 |        cpu |      3,370.76 μs |      1,752.598 μs |      96.066 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |       2048 |   float32 |        cpu |    212,171.47 μs |     56,310.518 μs |   3,086.569 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |       2048 |   float32 |        cpu |    221,002.13 μs |     41,025.760 μs |   2,248.760 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |       **2048** |   **float32** |       **cuda** |     **63,616.43 μs** |      **7,291.796 μs** |     **399.688 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |       2048 |   float32 |       cuda |      1,322.77 μs |        271.472 μs |      14.880 μs | 0.021 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |       2048 |   float32 |       cuda |     24,067.97 μs |     18,140.829 μs |     994.360 μs | 0.378 |    0.02 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |       2048 |   float32 |       cuda |     25,279.87 μs |     80,561.488 μs |   4,415.847 μs | 0.397 |    0.07 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |       2048 |   float32 |       cuda |        154.03 μs |         30.832 μs |       1.690 μs | 0.002 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |       2048 |   float32 |       cuda |        162.27 μs |          1.661 μs |       0.091 μs | 0.003 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |       2048 |   float32 |       cuda |     47,674.63 μs |      4,750.258 μs |     260.378 μs |  1.00 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |       2048 |   float32 |       cuda |     21,076.37 μs |      7,203.714 μs |     394.860 μs |  0.44 |    0.01 |       No |
|            zeros_RawTensor_Torch |        zeros |       2048 |   float32 |       cuda |     24,624.77 μs |      6,711.704 μs |     367.891 μs |  0.52 |    0.01 |       No |
|               zeros_Tensor_Torch |        zeros |       2048 |   float32 |       cuda |     23,139.23 μs |     29,178.589 μs |   1,599.377 μs |  0.49 |    0.03 |       No |
|        zeros_RawTensor_Reference |        zeros |       2048 |   float32 |       cuda |      1,058.62 μs |        179.112 μs |       9.818 μs |  0.02 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |       2048 |   float32 |       cuda |      1,100.22 μs |        514.303 μs |      28.191 μs |  0.02 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |       2048 |   float32 |       cuda |     47,680.19 μs |      2,587.525 μs |     141.831 μs |  1.00 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |       2048 |   float32 |       cuda |     19,705.07 μs |      4,581.428 μs |     251.124 μs |  0.41 |    0.01 |       No |
|             ones_RawTensor_Torch |         ones |       2048 |   float32 |       cuda |     21,791.23 μs |     29,520.893 μs |   1,618.140 μs |  0.46 |    0.04 |       No |
|                ones_Tensor_Torch |         ones |       2048 |   float32 |       cuda |     23,364.83 μs |     31,082.288 μs |   1,703.725 μs |  0.49 |    0.03 |       No |
|         ones_RawTensor_Reference |         ones |       2048 |   float32 |       cuda |      2,615.70 μs |      1,833.131 μs |     100.480 μs |  0.05 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |       2048 |   float32 |       cuda |      2,692.11 μs |        376.954 μs |      20.662 μs |  0.06 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |       2048 |   float32 |       cuda |     48,126.53 μs |     10,105.933 μs |     553.940 μs |  1.00 |    0.00 |      Yes |
|                  rand_TorchSharp |         rand |       2048 |   float32 |       cuda |     21,675.00 μs |      1,632.960 μs |      89.508 μs |  0.45 |    0.01 |       No |
|             rand_RawTensor_Torch |         rand |       2048 |   float32 |       cuda |     30,453.10 μs |     31,864.808 μs |   1,746.618 μs |  0.63 |    0.04 |       No |
|                rand_Tensor_Torch |         rand |       2048 |   float32 |       cuda |     25,948.73 μs |     49,432.318 μs |   2,709.552 μs |  0.54 |    0.06 |       No |
|         rand_RawTensor_Reference |         rand |       2048 |   float32 |       cuda |     32,801.41 μs |      9,136.316 μs |     500.792 μs |  0.68 |    0.02 |       No |
|            rand_Tensor_Reference |         rand |       2048 |   float32 |       cuda |     32,673.28 μs |     10,625.201 μs |     582.403 μs |  0.68 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |       2048 |   float32 |       cuda |     31,818.81 μs |      1,891.846 μs |     103.698 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |       2048 |   float32 |       cuda |     17,452.10 μs |      2,151.713 μs |     117.943 μs |  0.55 |    0.01 |       No |
|         addition_RawTensor_Torch |     addition |       2048 |   float32 |       cuda |     20,184.33 μs |      7,960.999 μs |     436.369 μs |  0.63 |    0.01 |       No |
|            addition_Tensor_Torch |     addition |       2048 |   float32 |       cuda |     23,911.80 μs |      1,356.674 μs |      74.364 μs |  0.75 |    0.00 |       No |
|     addition_RawTensor_Reference |     addition |       2048 |   float32 |       cuda |      7,814.06 μs |      5,352.686 μs |     293.399 μs |  0.25 |    0.01 |       No |
|        addition_Tensor_Reference |     addition |       2048 |   float32 |       cuda |      8,083.54 μs |      3,670.995 μs |     201.220 μs |  0.25 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |       2048 |   float32 |       cuda |     47,774.26 μs |      4,296.497 μs |     235.505 μs |  1.00 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |       2048 |   float32 |       cuda |     24,298.93 μs |      2,799.279 μs |     153.438 μs |  0.51 |    0.01 |       No |
|        addScalar_RawTensor_Torch |    addScalar |       2048 |   float32 |       cuda |     27,350.13 μs |      2,394.389 μs |     131.245 μs |  0.57 |    0.00 |       No |
|           addScalar_Tensor_Torch |    addScalar |       2048 |   float32 |       cuda |     44,249.10 μs |     30,991.933 μs |   1,698.772 μs |  0.93 |    0.03 |       No |
|    addScalar_RawTensor_Reference |    addScalar |       2048 |   float32 |       cuda |      2,519.22 μs |      1,317.023 μs |      72.190 μs |  0.05 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |       2048 |   float32 |       cuda |     13,035.87 μs |      2,437.949 μs |     133.632 μs |  0.27 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |       2048 |   float32 |       cuda |     31,773.66 μs |      1,190.060 μs |      65.231 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |       2048 |   float32 |       cuda |     17,411.57 μs |      3,378.927 μs |     185.210 μs |  0.55 |    0.01 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |       2048 |   float32 |       cuda |     21,518.17 μs |     16,632.759 μs |     911.698 μs |  0.68 |    0.03 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |       2048 |   float32 |       cuda |     62,684.00 μs |     44,510.941 μs |   2,439.795 μs |  1.97 |    0.08 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |       2048 |   float32 |       cuda |      7,727.15 μs |      4,712.084 μs |     258.285 μs |  0.24 |    0.01 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |       2048 |   float32 |       cuda |     21,135.50 μs |     12,428.352 μs |     681.240 μs |  0.67 |    0.02 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |       2048 |   float32 |       cuda |     16,073.08 μs |      4,463.873 μs |     244.680 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |       2048 |   float32 |       cuda |     11,261.70 μs |      1,842.100 μs |     100.972 μs |  0.70 |    0.01 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |       2048 |   float32 |       cuda |     12,397.17 μs |     17,990.233 μs |     986.105 μs |  0.77 |    0.06 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |       2048 |   float32 |       cuda |     24,968.07 μs |     28,689.185 μs |   1,572.551 μs |  1.55 |    0.11 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |       2048 |   float32 |       cuda |      6,360.59 μs |      2,544.442 μs |     139.469 μs |  0.40 |    0.00 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |       2048 |   float32 |       cuda |      8,268.70 μs |      1,960.185 μs |     107.444 μs |  0.51 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |       2048 |   float32 |       cuda |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |       2048 |   float32 |       cuda |      2,985.87 μs |      9,265.520 μs |     507.874 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |       2048 |   float32 |       cuda |      3,816.03 μs |     15,602.597 μs |     855.231 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |       2048 |   float32 |       cuda |      3,394.67 μs |      1,263.915 μs |      69.279 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |       2048 |   float32 |       cuda |    224,079.30 μs |     25,358.359 μs |   1,389.977 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |       2048 |   float32 |       cuda |    224,451.37 μs |     45,571.366 μs |   2,497.920 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |       **2048** |   **float64** |        **cpu** |     **32,159.14 μs** |      **7,733.801 μs** |     **423.916 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |       2048 |   float64 |        cpu |      1,667.00 μs |        508.621 μs |      27.879 μs | 0.052 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |       2048 |   float64 |        cpu |      4,353.47 μs |      1,292.680 μs |      70.856 μs | 0.135 |    0.00 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |       2048 |   float64 |        cpu |      4,478.52 μs |        827.333 μs |      45.349 μs | 0.139 |    0.00 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |       2048 |   float64 |        cpu |        172.40 μs |         22.369 μs |       1.226 μs | 0.005 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |       2048 |   float64 |        cpu |        172.01 μs |         65.924 μs |       3.613 μs | 0.005 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |       2048 |   float64 |        cpu |     30,925.95 μs |      3,539.886 μs |     194.033 μs |  1.00 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |       2048 |   float64 |        cpu |     10,861.51 μs |      3,061.283 μs |     167.799 μs |  0.35 |    0.01 |       No |
|            zeros_RawTensor_Torch |        zeros |       2048 |   float64 |        cpu |     18,467.47 μs |     18,788.084 μs |   1,029.838 μs |  0.60 |    0.03 |       No |
|               zeros_Tensor_Torch |        zeros |       2048 |   float64 |        cpu |     17,780.06 μs |     12,565.501 μs |     688.758 μs |  0.57 |    0.02 |       No |
|        zeros_RawTensor_Reference |        zeros |       2048 |   float64 |        cpu |      1,764.41 μs |         93.105 μs |       5.103 μs |  0.06 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |       2048 |   float64 |        cpu |      1,756.09 μs |         57.463 μs |       3.150 μs |  0.06 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |       2048 |   float64 |        cpu |     31,418.63 μs |      4,686.472 μs |     256.881 μs |  1.00 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |       2048 |   float64 |        cpu |     10,957.88 μs |      1,449.042 μs |      79.427 μs |  0.35 |    0.01 |       No |
|             ones_RawTensor_Torch |         ones |       2048 |   float64 |        cpu |     17,912.22 μs |     10,206.603 μs |     559.458 μs |  0.57 |    0.02 |       No |
|                ones_Tensor_Torch |         ones |       2048 |   float64 |        cpu |     21,707.72 μs |    122,188.923 μs |   6,697.587 μs |  0.69 |    0.21 |       No |
|         ones_RawTensor_Reference |         ones |       2048 |   float64 |        cpu |      3,168.81 μs |        179.528 μs |       9.841 μs |  0.10 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |       2048 |   float64 |        cpu |      3,175.56 μs |        121.243 μs |       6.646 μs |  0.10 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |       2048 |   float64 |        cpu |     62,200.10 μs |     12,316.182 μs |     675.092 μs |  1.00 |    0.00 |      Yes |
|                  rand_TorchSharp |         rand |       2048 |   float64 |        cpu |     26,927.25 μs |      3,994.360 μs |     218.944 μs |  0.43 |    0.00 |       No |
|             rand_RawTensor_Torch |         rand |       2048 |   float64 |        cpu |     52,299.57 μs |     14,233.659 μs |     780.195 μs |  0.84 |    0.02 |       No |
|                rand_Tensor_Torch |         rand |       2048 |   float64 |        cpu |     52,857.29 μs |      4,668.168 μs |     255.878 μs |  0.85 |    0.01 |       No |
|         rand_RawTensor_Reference |         rand |       2048 |   float64 |        cpu |     32,656.28 μs |      7,382.556 μs |     404.663 μs |  0.53 |    0.01 |       No |
|            rand_Tensor_Reference |         rand |       2048 |   float64 |        cpu |     33,692.22 μs |        642.715 μs |      35.229 μs |  0.54 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |       2048 |   float64 |        cpu |     15,901.52 μs |      2,669.299 μs |     146.313 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |       2048 |   float64 |        cpu |     11,946.62 μs |        893.365 μs |      48.968 μs |  0.75 |    0.00 |       No |
|         addition_RawTensor_Torch |     addition |       2048 |   float64 |        cpu |     10,604.06 μs |      4,345.346 μs |     238.183 μs |  0.67 |    0.02 |       No |
|            addition_Tensor_Torch |     addition |       2048 |   float64 |        cpu |     13,427.30 μs |      3,299.934 μs |     180.881 μs |  0.84 |    0.01 |       No |
|     addition_RawTensor_Reference |     addition |       2048 |   float64 |        cpu |      6,018.52 μs |        125.136 μs |       6.859 μs |  0.38 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |       2048 |   float64 |        cpu |      7,539.63 μs |        427.486 μs |      23.432 μs |  0.47 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |       2048 |   float64 |        cpu |     31,140.80 μs |      4,318.154 μs |     236.693 μs |  1.00 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |       2048 |   float64 |        cpu |     20,163.08 μs |      3,861.889 μs |     211.683 μs |  0.65 |    0.00 |       No |
|        addScalar_RawTensor_Torch |    addScalar |       2048 |   float64 |        cpu |     21,250.22 μs |      2,012.741 μs |     110.325 μs |  0.68 |    0.00 |       No |
|           addScalar_Tensor_Torch |    addScalar |       2048 |   float64 |        cpu |     24,204.43 μs |      7,290.391 μs |     399.611 μs |  0.78 |    0.01 |       No |
|    addScalar_RawTensor_Reference |    addScalar |       2048 |   float64 |        cpu |      2,423.91 μs |         96.136 μs |       5.270 μs |  0.08 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |       2048 |   float64 |        cpu |     14,369.36 μs |        186.648 μs |      10.231 μs |  0.46 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |       2048 |   float64 |        cpu |     15,932.44 μs |      3,191.969 μs |     174.963 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |       2048 |   float64 |        cpu |     11,258.58 μs |      5,084.135 μs |     278.679 μs |  0.71 |    0.01 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |       2048 |   float64 |        cpu |     11,641.12 μs |      7,747.427 μs |     424.663 μs |  0.73 |    0.03 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |       2048 |   float64 |        cpu |     42,032.27 μs |     18,987.588 μs |   1,040.774 μs |  2.64 |    0.04 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |       2048 |   float64 |        cpu |      6,104.75 μs |      1,387.033 μs |      76.028 μs |  0.38 |    0.01 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |       2048 |   float64 |        cpu |     22,795.24 μs |      8,906.261 μs |     488.182 μs |  1.43 |    0.03 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |       2048 |   float64 |        cpu |     15,572.24 μs |      3,637.019 μs |     199.357 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |       2048 |   float64 |        cpu |      4,973.36 μs |      3,624.803 μs |     198.688 μs |  0.32 |    0.02 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |       2048 |   float64 |        cpu |      4,902.32 μs |        951.826 μs |      52.173 μs |  0.31 |    0.00 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |       2048 |   float64 |        cpu |     13,904.52 μs |      7,336.717 μs |     402.150 μs |  0.89 |    0.04 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |       2048 |   float64 |        cpu |      7,584.26 μs |        625.003 μs |      34.259 μs |  0.49 |    0.00 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |       2048 |   float64 |        cpu |      7,555.00 μs |        992.418 μs |      54.398 μs |  0.49 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |       2048 |   float64 |        cpu |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |       2048 |   float64 |        cpu |      2,863.56 μs |      1,043.441 μs |      57.195 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |       2048 |   float64 |        cpu |      2,892.08 μs |      1,262.847 μs |      69.221 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |       2048 |   float64 |        cpu |      3,330.78 μs |      2,176.866 μs |     119.321 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |       2048 |   float64 |        cpu |    204,370.90 μs |     84,729.632 μs |   4,644.317 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |       2048 |   float64 |        cpu |    200,059.67 μs |     58,783.268 μs |   3,222.109 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |       **2048** |   **float64** |       **cuda** |     **62,228.67 μs** |     **12,810.122 μs** |     **702.166 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |       2048 |   float64 |       cuda |      1,304.60 μs |        179.058 μs |       9.815 μs | 0.021 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |       2048 |   float64 |       cuda |     23,042.10 μs |      8,436.210 μs |     462.417 μs | 0.370 |    0.01 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |       2048 |   float64 |       cuda |     26,207.27 μs |     91,518.369 μs |   5,016.431 μs | 0.421 |    0.08 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |       2048 |   float64 |       cuda |        152.05 μs |         42.681 μs |       2.339 μs | 0.002 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |       2048 |   float64 |       cuda |        169.82 μs |          7.541 μs |       0.413 μs | 0.003 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |       2048 |   float64 |       cuda |     46,782.03 μs |     13,434.849 μs |     736.409 μs |  1.00 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |       2048 |   float64 |       cuda |     22,152.27 μs |     39,578.223 μs |   2,169.416 μs |  0.47 |    0.05 |       No |
|            zeros_RawTensor_Torch |        zeros |       2048 |   float64 |       cuda |     22,027.83 μs |      2,638.463 μs |     144.623 μs |  0.47 |    0.01 |       No |
|               zeros_Tensor_Torch |        zeros |       2048 |   float64 |       cuda |     21,774.60 μs |      2,597.766 μs |     142.392 μs |  0.47 |    0.01 |       No |
|        zeros_RawTensor_Reference |        zeros |       2048 |   float64 |       cuda |      1,733.64 μs |        117.564 μs |       6.444 μs |  0.04 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |       2048 |   float64 |       cuda |      1,751.28 μs |        238.000 μs |      13.046 μs |  0.04 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |       2048 |   float64 |       cuda |     46,616.64 μs |     11,524.838 μs |     631.715 μs |  1.00 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |       2048 |   float64 |       cuda |     19,801.27 μs |      5,161.251 μs |     282.906 μs |  0.42 |    0.00 |       No |
|             ones_RawTensor_Torch |         ones |       2048 |   float64 |       cuda |     21,608.50 μs |        208.897 μs |      11.450 μs |  0.46 |    0.01 |       No |
|                ones_Tensor_Torch |         ones |       2048 |   float64 |       cuda |     21,704.83 μs |      5,355.493 μs |     293.553 μs |  0.47 |    0.01 |       No |
|         ones_RawTensor_Reference |         ones |       2048 |   float64 |       cuda |      3,176.47 μs |         92.186 μs |       5.053 μs |  0.07 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |       2048 |   float64 |       cuda |      3,182.27 μs |        160.913 μs |       8.820 μs |  0.07 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |       2048 |   float64 |       cuda |     46,684.78 μs |      8,816.789 μs |     483.278 μs |  1.00 |    0.00 |      Yes |
|                  rand_TorchSharp |         rand |       2048 |   float64 |       cuda |     21,147.17 μs |      5,081.743 μs |     278.547 μs |  0.45 |    0.01 |       No |
|             rand_RawTensor_Torch |         rand |       2048 |   float64 |       cuda |     23,601.17 μs |     38,126.194 μs |   2,089.825 μs |  0.51 |    0.05 |       No |
|                rand_Tensor_Torch |         rand |       2048 |   float64 |       cuda |     23,824.57 μs |      1,688.713 μs |      92.564 μs |  0.51 |    0.00 |       No |
|         rand_RawTensor_Reference |         rand |       2048 |   float64 |       cuda |     32,429.80 μs |      1,770.784 μs |      97.063 μs |  0.69 |    0.01 |       No |
|            rand_Tensor_Reference |         rand |       2048 |   float64 |       cuda |     33,787.98 μs |      1,158.230 μs |      63.486 μs |  0.72 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |       2048 |   float64 |       cuda |     31,116.31 μs |      3,889.625 μs |     213.203 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |       2048 |   float64 |       cuda |     17,558.27 μs |      6,415.933 μs |     351.679 μs |  0.56 |    0.01 |       No |
|         addition_RawTensor_Torch |     addition |       2048 |   float64 |       cuda |     19,088.07 μs |      2,081.146 μs |     114.075 μs |  0.61 |    0.00 |       No |
|            addition_Tensor_Torch |     addition |       2048 |   float64 |       cuda |     24,072.73 μs |        124.997 μs |       6.852 μs |  0.77 |    0.01 |       No |
|     addition_RawTensor_Reference |     addition |       2048 |   float64 |       cuda |      6,011.89 μs |        746.801 μs |      40.935 μs |  0.19 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |       2048 |   float64 |       cuda |      7,639.14 μs |        295.593 μs |      16.202 μs |  0.25 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |       2048 |   float64 |       cuda |     46,207.25 μs |      8,898.866 μs |     487.777 μs |  1.00 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |       2048 |   float64 |       cuda |     24,538.67 μs |      5,751.274 μs |     315.247 μs |  0.53 |    0.01 |       No |
|        addScalar_RawTensor_Torch |    addScalar |       2048 |   float64 |       cuda |     27,393.47 μs |     34,240.541 μs |   1,876.840 μs |  0.59 |    0.04 |       No |
|           addScalar_Tensor_Torch |    addScalar |       2048 |   float64 |       cuda |     43,095.30 μs |      3,769.783 μs |     206.635 μs |  0.93 |    0.01 |       No |
|    addScalar_RawTensor_Reference |    addScalar |       2048 |   float64 |       cuda |      2,435.67 μs |         22.789 μs |       1.249 μs |  0.05 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |       2048 |   float64 |       cuda |     14,384.84 μs |        245.582 μs |      13.461 μs |  0.31 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |       2048 |   float64 |       cuda |     31,134.82 μs |        432.012 μs |      23.680 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |       2048 |   float64 |       cuda |     17,187.33 μs |      6,062.166 μs |     332.288 μs |  0.55 |    0.01 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |       2048 |   float64 |       cuda |     19,975.13 μs |      3,122.961 μs |     171.180 μs |  0.64 |    0.01 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |       2048 |   float64 |       cuda |     57,605.63 μs |     16,305.114 μs |     893.738 μs |  1.85 |    0.03 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |       2048 |   float64 |       cuda |      6,127.17 μs |      1,626.487 μs |      89.153 μs |  0.20 |    0.00 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |       2048 |   float64 |       cuda |     21,967.28 μs |        919.555 μs |      50.404 μs |  0.71 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |       2048 |   float64 |       cuda |     15,823.38 μs |      2,629.193 μs |     144.115 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |       2048 |   float64 |       cuda |     11,331.17 μs |      1,068.281 μs |      58.556 μs |  0.72 |    0.00 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |       2048 |   float64 |       cuda |     12,086.37 μs |      9,027.161 μs |     494.809 μs |  0.76 |    0.03 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |       2048 |   float64 |       cuda |     23,676.00 μs |      3,313.691 μs |     181.635 μs |  1.50 |    0.02 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |       2048 |   float64 |       cuda |      7,444.77 μs |        247.938 μs |      13.590 μs |  0.47 |    0.01 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |       2048 |   float64 |       cuda |      7,593.63 μs |        150.563 μs |       8.253 μs |  0.48 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |       2048 |   float64 |       cuda |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |       2048 |   float64 |       cuda |      2,658.20 μs |        388.180 μs |      21.277 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |       2048 |   float64 |       cuda |      2,227.67 μs |        449.427 μs |      24.635 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |       2048 |   float64 |       cuda |      2,693.23 μs |        516.952 μs |      28.336 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |       2048 |   float64 |       cuda |    202,368.77 μs |     14,613.984 μs |     801.042 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |       2048 |   float64 |       cuda |    199,368.73 μs |     28,353.703 μs |   1,554.162 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |       **2048** |     **int32** |        **cpu** |     **31,064.89 μs** |      **3,137.235 μs** |     **171.962 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |       2048 |     int32 |        cpu |      1,548.66 μs |      1,007.049 μs |      55.200 μs | 0.050 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |       2048 |     int32 |        cpu |      3,475.56 μs |      1,049.341 μs |      57.518 μs | 0.112 |    0.00 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |       2048 |     int32 |        cpu |      3,485.59 μs |        336.322 μs |      18.435 μs | 0.112 |    0.00 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |       2048 |     int32 |        cpu |        106.09 μs |         40.470 μs |       2.218 μs | 0.003 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |       2048 |     int32 |        cpu |        110.93 μs |          4.315 μs |       0.237 μs | 0.004 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |       2048 |     int32 |        cpu |     16,667.35 μs |     10,349.217 μs |     567.276 μs |  1.00 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |       2048 |     int32 |        cpu |     10,635.21 μs |      4,788.399 μs |     262.468 μs |  0.64 |    0.04 |       No |
|            zeros_RawTensor_Torch |        zeros |       2048 |     int32 |        cpu |      9,363.86 μs |      1,806.601 μs |      99.026 μs |  0.56 |    0.02 |       No |
|               zeros_Tensor_Torch |        zeros |       2048 |     int32 |        cpu |      9,894.49 μs |      3,409.699 μs |     186.897 μs |  0.59 |    0.03 |       No |
|        zeros_RawTensor_Reference |        zeros |       2048 |     int32 |        cpu |        981.53 μs |        250.571 μs |      13.735 μs |  0.06 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |       2048 |     int32 |        cpu |        983.96 μs |         71.558 μs |       3.922 μs |  0.06 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |       2048 |     int32 |        cpu |     15,855.37 μs |      1,545.306 μs |      84.703 μs |  1.00 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |       2048 |     int32 |        cpu |     10,793.87 μs |      4,405.663 μs |     241.489 μs |  0.68 |    0.02 |       No |
|             ones_RawTensor_Torch |         ones |       2048 |     int32 |        cpu |      9,883.73 μs |      3,250.088 μs |     178.148 μs |  0.62 |    0.01 |       No |
|                ones_Tensor_Torch |         ones |       2048 |     int32 |        cpu |     10,020.94 μs |      2,217.531 μs |     121.550 μs |  0.63 |    0.01 |       No |
|         ones_RawTensor_Reference |         ones |       2048 |     int32 |        cpu |      2,425.02 μs |        550.612 μs |      30.181 μs |  0.15 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |       2048 |     int32 |        cpu |      2,419.88 μs |        139.476 μs |       7.645 μs |  0.15 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |       2048 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |      Yes |
|                  rand_TorchSharp |         rand |       2048 |     int32 |        cpu |     39,761.39 μs |     10,600.405 μs |     581.044 μs |     ? |       ? |       No |
|             rand_RawTensor_Torch |         rand |       2048 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |       No |
|                rand_Tensor_Torch |         rand |       2048 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |       No |
|         rand_RawTensor_Reference |         rand |       2048 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |       No |
|            rand_Tensor_Reference |         rand |       2048 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |       2048 |     int32 |        cpu |     15,586.76 μs |      1,260.330 μs |      69.083 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |       2048 |     int32 |        cpu |     11,598.91 μs |      4,701.739 μs |     257.718 μs |  0.74 |    0.02 |       No |
|         addition_RawTensor_Torch |     addition |       2048 |     int32 |        cpu |     10,346.92 μs |      1,660.795 μs |      91.034 μs |  0.66 |    0.00 |       No |
|            addition_Tensor_Torch |     addition |       2048 |     int32 |        cpu |     13,602.14 μs |        675.091 μs |      37.004 μs |  0.87 |    0.00 |       No |
|     addition_RawTensor_Reference |     addition |       2048 |     int32 |        cpu |      5,907.41 μs |        135.427 μs |       7.423 μs |  0.38 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |       2048 |     int32 |        cpu |      7,407.95 μs |        275.814 μs |      15.118 μs |  0.48 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |       2048 |     int32 |        cpu |     30,754.74 μs |      4,689.078 μs |     257.024 μs |  1.00 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |       2048 |     int32 |        cpu |     19,769.96 μs |      5,413.089 μs |     296.710 μs |  0.64 |    0.01 |       No |
|        addScalar_RawTensor_Torch |    addScalar |       2048 |     int32 |        cpu |     20,729.78 μs |      4,482.032 μs |     245.675 μs |  0.67 |    0.00 |       No |
|           addScalar_Tensor_Torch |    addScalar |       2048 |     int32 |        cpu |     42,907.01 μs |     17,337.662 μs |     950.336 μs |  1.40 |    0.04 |       No |
|    addScalar_RawTensor_Reference |    addScalar |       2048 |     int32 |        cpu |      2,735.50 μs |      1,236.771 μs |      67.792 μs |  0.09 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |       2048 |     int32 |        cpu |    136,260.23 μs |      3,023.506 μs |     165.729 μs |  4.43 |    0.04 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |       2048 |     int32 |        cpu |     15,577.53 μs |      1,899.516 μs |     104.119 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |       2048 |     int32 |        cpu |     11,163.11 μs |      4,312.828 μs |     236.401 μs |  0.72 |    0.01 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |       2048 |     int32 |        cpu |     10,839.39 μs |      5,350.184 μs |     293.262 μs |  0.70 |    0.02 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |       2048 |     int32 |        cpu |     39,534.49 μs |     14,008.093 μs |     767.831 μs |  2.54 |    0.06 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |       2048 |     int32 |        cpu |      6,128.19 μs |      2,976.556 μs |     163.155 μs |  0.39 |    0.01 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |       2048 |     int32 |        cpu |    265,660.20 μs |     29,918.652 μs |   1,639.942 μs | 17.05 |    0.16 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |       2048 |     int32 |        cpu |     15,656.71 μs |      4,096.742 μs |     224.556 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |       2048 |     int32 |        cpu |      4,608.59 μs |      1,669.067 μs |      91.487 μs |  0.29 |    0.00 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |       2048 |     int32 |        cpu |      4,458.96 μs |        578.541 μs |      31.712 μs |  0.28 |    0.00 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |       2048 |     int32 |        cpu |     13,650.00 μs |      3,151.961 μs |     172.770 μs |  0.87 |    0.02 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |       2048 |     int32 |        cpu |      5,982.88 μs |        268.713 μs |      14.729 μs |  0.38 |    0.01 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |       2048 |     int32 |        cpu |      7,573.71 μs |        115.831 μs |       6.349 μs |  0.48 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |       2048 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |       2048 |     int32 |        cpu |      6,568.12 μs |        775.612 μs |      42.514 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |       2048 |     int32 |        cpu |      6,518.67 μs |        266.019 μs |      14.581 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |       2048 |     int32 |        cpu |      6,891.78 μs |        188.297 μs |      10.321 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |       2048 |     int32 |        cpu |    203,587.80 μs |     29,297.139 μs |   1,605.875 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |       2048 |     int32 |        cpu |    202,145.53 μs |     24,581.407 μs |   1,347.390 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |       **2048** |     **int32** |       **cuda** |     **61,561.96 μs** |      **6,256.803 μs** |     **342.957 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |       2048 |     int32 |       cuda |      1,294.43 μs |        145.840 μs |       7.994 μs | 0.021 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |       2048 |     int32 |       cuda |     22,205.67 μs |      7,277.548 μs |     398.907 μs | 0.361 |    0.01 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |       2048 |     int32 |       cuda |     22,383.67 μs |      5,260.236 μs |     288.331 μs | 0.364 |    0.01 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |       2048 |     int32 |       cuda |        108.04 μs |          4.435 μs |       0.243 μs | 0.002 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |       2048 |     int32 |       cuda |        110.57 μs |          2.535 μs |       0.139 μs | 0.002 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |       2048 |     int32 |       cuda |     46,586.97 μs |     10,853.149 μs |     594.898 μs |  1.00 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |       2048 |     int32 |       cuda |     19,610.80 μs |      3,129.765 μs |     171.553 μs |  0.42 |    0.01 |       No |
|            zeros_RawTensor_Torch |        zeros |       2048 |     int32 |       cuda |     21,799.13 μs |      2,966.022 μs |     162.578 μs |  0.47 |    0.00 |       No |
|               zeros_Tensor_Torch |        zeros |       2048 |     int32 |       cuda |     22,027.83 μs |      4,013.049 μs |     219.969 μs |  0.47 |    0.01 |       No |
|        zeros_RawTensor_Reference |        zeros |       2048 |     int32 |       cuda |        991.01 μs |        220.224 μs |      12.071 μs |  0.02 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |       2048 |     int32 |       cuda |        983.09 μs |        159.852 μs |       8.762 μs |  0.02 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |       2048 |     int32 |       cuda |     46,567.60 μs |     10,703.947 μs |     586.719 μs |  1.00 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |       2048 |     int32 |       cuda |     19,961.83 μs |      4,575.273 μs |     250.786 μs |  0.43 |    0.00 |       No |
|             ones_RawTensor_Torch |         ones |       2048 |     int32 |       cuda |     21,954.07 μs |      5,512.297 μs |     302.148 μs |  0.47 |    0.01 |       No |
|                ones_Tensor_Torch |         ones |       2048 |     int32 |       cuda |     20,741.60 μs |      3,014.868 μs |     165.255 μs |  0.45 |    0.01 |       No |
|         ones_RawTensor_Reference |         ones |       2048 |     int32 |       cuda |      2,411.94 μs |        271.799 μs |      14.898 μs |  0.05 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |       2048 |     int32 |       cuda |      2,420.25 μs |        238.403 μs |      13.068 μs |  0.05 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |       2048 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |      Yes |
|                  rand_TorchSharp |         rand |       2048 |     int32 |       cuda |     20,941.43 μs |     27,298.642 μs |   1,496.331 μs |     ? |       ? |       No |
|             rand_RawTensor_Torch |         rand |       2048 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|                rand_Tensor_Torch |         rand |       2048 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|         rand_RawTensor_Reference |         rand |       2048 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|            rand_Tensor_Reference |         rand |       2048 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |       2048 |     int32 |       cuda |     31,153.87 μs |      2,820.231 μs |     154.586 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |       2048 |     int32 |       cuda |     17,388.93 μs |      5,154.564 μs |     282.539 μs |  0.56 |    0.01 |       No |
|         addition_RawTensor_Torch |     addition |       2048 |     int32 |       cuda |     19,400.93 μs |        655.923 μs |      35.953 μs |  0.62 |    0.00 |       No |
|            addition_Tensor_Torch |     addition |       2048 |     int32 |       cuda |     25,606.43 μs |     46,873.159 μs |   2,569.276 μs |  0.82 |    0.08 |       No |
|     addition_RawTensor_Reference |     addition |       2048 |     int32 |       cuda |      5,938.93 μs |        525.007 μs |      28.777 μs |  0.19 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |       2048 |     int32 |       cuda |      7,404.09 μs |        382.351 μs |      20.958 μs |  0.24 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |       2048 |     int32 |       cuda |     46,263.51 μs |      6,432.431 μs |     352.583 μs |  1.00 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |       2048 |     int32 |       cuda |     24,785.40 μs |      3,536.050 μs |     193.823 μs |  0.54 |    0.01 |       No |
|        addScalar_RawTensor_Torch |    addScalar |       2048 |     int32 |       cuda |     26,835.00 μs |      1,414.595 μs |      77.539 μs |  0.58 |    0.00 |       No |
|           addScalar_Tensor_Torch |    addScalar |       2048 |     int32 |       cuda |     76,996.73 μs |     44,080.853 μs |   2,416.220 μs |  1.66 |    0.06 |       No |
|    addScalar_RawTensor_Reference |    addScalar |       2048 |     int32 |       cuda |      2,684.07 μs |         95.312 μs |       5.224 μs |  0.06 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |       2048 |     int32 |       cuda |    133,972.23 μs |      7,979.124 μs |     437.363 μs |  2.90 |    0.03 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |       2048 |     int32 |       cuda |     31,116.41 μs |      2,875.971 μs |     157.642 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |       2048 |     int32 |       cuda |     18,041.07 μs |      2,260.039 μs |     123.880 μs |  0.58 |    0.00 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |       2048 |     int32 |       cuda |     19,601.40 μs |      4,055.794 μs |     222.312 μs |  0.63 |    0.00 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |       2048 |     int32 |       cuda |     55,435.47 μs |      2,223.096 μs |     121.855 μs |  1.78 |    0.01 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |       2048 |     int32 |       cuda |      5,972.79 μs |        528.435 μs |      28.965 μs |  0.19 |    0.00 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |       2048 |     int32 |       cuda |    264,246.80 μs |      7,246.335 μs |     397.196 μs |  8.49 |    0.06 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |       2048 |     int32 |       cuda |     15,866.81 μs |      2,264.732 μs |     124.138 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |       2048 |     int32 |       cuda |     10,968.77 μs |        408.078 μs |      22.368 μs |  0.69 |    0.01 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |       2048 |     int32 |       cuda |     13,976.27 μs |     75,383.718 μs |   4,132.036 μs |  0.88 |    0.26 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |       2048 |     int32 |       cuda |     23,689.73 μs |      8,805.334 μs |     482.650 μs |  1.49 |    0.03 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |       2048 |     int32 |       cuda |      5,968.19 μs |        212.350 μs |      11.640 μs |  0.38 |    0.00 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |       2048 |     int32 |       cuda |      7,414.60 μs |         75.872 μs |       4.159 μs |  0.47 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |       2048 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |       2048 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |       2048 |     int32 |       cuda |     13,212.40 μs |      1,653.426 μs |      90.630 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |       2048 |     int32 |       cuda |     13,788.90 μs |      1,133.527 μs |      62.132 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |       2048 |     int32 |       cuda |    201,432.20 μs |     11,858.194 μs |     649.988 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |       2048 |     int32 |       cuda |    200,489.67 μs |     12,019.521 μs |     658.830 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |      **65536** |   **float32** |        **cpu** |     **31,797.70 μs** |      **4,089.843 μs** |     **224.178 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |      65536 |   float32 |        cpu |         43.45 μs |         24.229 μs |       1.328 μs | 0.001 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |      65536 |   float32 |        cpu |      1,611.54 μs |        746.938 μs |      40.942 μs | 0.051 |    0.00 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |      65536 |   float32 |        cpu |      1,723.82 μs |        261.815 μs |      14.351 μs | 0.054 |    0.00 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |      65536 |   float32 |        cpu |      2,427.15 μs |        275.262 μs |      15.088 μs | 0.076 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |      65536 |   float32 |        cpu |      2,352.09 μs |        273.250 μs |      14.978 μs | 0.074 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |      65536 |   float32 |        cpu |     15,484.73 μs |      1,105.432 μs |      60.592 μs |  1.00 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |      65536 |   float32 |        cpu |      7,207.10 μs |      4,029.987 μs |     220.897 μs |  0.47 |    0.02 |       No |
|            zeros_RawTensor_Torch |        zeros |      65536 |   float32 |        cpu |      4,006.31 μs |      1,797.919 μs |      98.550 μs |  0.26 |    0.01 |       No |
|               zeros_Tensor_Torch |        zeros |      65536 |   float32 |        cpu |      3,799.56 μs |      1,939.946 μs |     106.335 μs |  0.25 |    0.01 |       No |
|        zeros_RawTensor_Reference |        zeros |      65536 |   float32 |        cpu |      3,267.92 μs |        370.167 μs |      20.290 μs |  0.21 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |      65536 |   float32 |        cpu |      3,294.26 μs |        211.407 μs |      11.588 μs |  0.21 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |      65536 |   float32 |        cpu |     15,454.43 μs |      1,430.805 μs |      78.427 μs |  1.00 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |      65536 |   float32 |        cpu |      6,813.57 μs |     11,613.279 μs |     636.563 μs |  0.44 |    0.04 |       No |
|             ones_RawTensor_Torch |         ones |      65536 |   float32 |        cpu |      3,988.74 μs |      1,047.074 μs |      57.394 μs |  0.26 |    0.00 |       No |
|                ones_Tensor_Torch |         ones |      65536 |   float32 |        cpu |      3,860.19 μs |      5,183.177 μs |     284.107 μs |  0.25 |    0.02 |       No |
|         ones_RawTensor_Reference |         ones |      65536 |   float32 |        cpu |      4,910.28 μs |        535.589 μs |      29.357 μs |  0.32 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |      65536 |   float32 |        cpu |      4,943.82 μs |        685.983 μs |      37.601 μs |  0.32 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |      65536 |   float32 |        cpu |     30,939.67 μs |      3,490.504 μs |     191.326 μs |  1.00 |    0.00 |      Yes |
|                  rand_TorchSharp |         rand |      65536 |   float32 |        cpu |     42,031.62 μs |     16,595.021 μs |     909.629 μs |  1.36 |    0.03 |       No |
|             rand_RawTensor_Torch |         rand |      65536 |   float32 |        cpu |     19,701.49 μs |      1,260.629 μs |      69.099 μs |  0.64 |    0.00 |       No |
|                rand_Tensor_Torch |         rand |      65536 |   float32 |        cpu |     19,687.16 μs |      1,216.902 μs |      66.703 μs |  0.64 |    0.00 |       No |
|         rand_RawTensor_Reference |         rand |      65536 |   float32 |        cpu |     34,426.56 μs |      2,068.028 μs |     113.356 μs |  1.11 |    0.01 |       No |
|            rand_Tensor_Reference |         rand |      65536 |   float32 |        cpu |     33,592.06 μs |      2,534.634 μs |     138.932 μs |  1.09 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |      65536 |   float32 |        cpu |     15,599.92 μs |      1,901.496 μs |     104.227 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |      65536 |   float32 |        cpu |      4,591.18 μs |      4,252.656 μs |     233.102 μs |  0.29 |    0.02 |       No |
|         addition_RawTensor_Torch |     addition |      65536 |   float32 |        cpu |      4,704.22 μs |      4,015.190 μs |     220.086 μs |  0.30 |    0.01 |       No |
|            addition_Tensor_Torch |     addition |      65536 |   float32 |        cpu |      4,758.09 μs |      2,011.586 μs |     110.262 μs |  0.30 |    0.01 |       No |
|     addition_RawTensor_Reference |     addition |      65536 |   float32 |        cpu |      9,851.46 μs |      1,335.227 μs |      73.188 μs |  0.63 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |      65536 |   float32 |        cpu |      9,300.54 μs |        369.378 μs |      20.247 μs |  0.60 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |      65536 |   float32 |        cpu |     15,576.14 μs |      1,134.871 μs |      62.206 μs |  1.00 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |      65536 |   float32 |        cpu |      5,052.48 μs |      3,384.995 μs |     185.543 μs |  0.32 |    0.01 |       No |
|        addScalar_RawTensor_Torch |    addScalar |      65536 |   float32 |        cpu |      4,944.19 μs |        923.823 μs |      50.638 μs |  0.32 |    0.00 |       No |
|           addScalar_Tensor_Torch |    addScalar |      65536 |   float32 |        cpu |      5,514.43 μs |      1,590.268 μs |      87.168 μs |  0.35 |    0.01 |       No |
|    addScalar_RawTensor_Reference |    addScalar |      65536 |   float32 |        cpu |      5,002.28 μs |      1,176.993 μs |      64.515 μs |  0.32 |    0.01 |       No |
|       addScalar_Tensor_Reference |    addScalar |      65536 |   float32 |        cpu |     12,987.32 μs |      3,124.870 μs |     171.285 μs |  0.83 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |      65536 |   float32 |        cpu |     15,587.51 μs |      1,476.590 μs |      80.937 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |      65536 |   float32 |        cpu |      4,529.01 μs |        943.952 μs |      51.741 μs |  0.29 |    0.00 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |      65536 |   float32 |        cpu |      4,833.81 μs |        611.260 μs |      33.505 μs |  0.31 |    0.00 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |      65536 |   float32 |        cpu |      9,603.92 μs |      9,343.103 μs |     512.127 μs |  0.62 |    0.04 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |      65536 |   float32 |        cpu |     10,021.19 μs |      2,514.977 μs |     137.854 μs |  0.64 |    0.01 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |      65536 |   float32 |        cpu |     18,423.86 μs |      2,197.726 μs |     120.465 μs |  1.18 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |      65536 |   float32 |        cpu |     15,579.61 μs |      1,579.786 μs |      86.593 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |      65536 |   float32 |        cpu |      1,890.25 μs |      1,065.860 μs |      58.423 μs |  0.12 |    0.00 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |      65536 |   float32 |        cpu |      1,911.43 μs |        646.615 μs |      35.443 μs |  0.12 |    0.00 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |      65536 |   float32 |        cpu |      4,742.18 μs |      5,597.830 μs |     306.836 μs |  0.30 |    0.02 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |      65536 |   float32 |        cpu |      8,545.59 μs |      1,538.109 μs |      84.309 μs |  0.55 |    0.00 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |      65536 |   float32 |        cpu |      9,301.56 μs |      2,147.546 μs |     117.714 μs |  0.60 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |      65536 |   float32 |        cpu |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |      65536 |   float32 |        cpu |      1,335.40 μs |      2,142.990 μs |     117.465 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |      65536 |   float32 |        cpu |      1,185.93 μs |      1,249.886 μs |      68.510 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |      65536 |   float32 |        cpu |      1,157.29 μs |      1,081.050 μs |      59.256 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |      65536 |   float32 |        cpu |    923,389.43 μs |     12,616.075 μs |     691.530 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |      65536 |   float32 |        cpu |    934,786.93 μs |    113,265.676 μs |   6,208.474 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |      **65536** |   **float32** |       **cuda** |     **39,420.56 μs** |     **52,420.831 μs** |   **2,873.363 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |      65536 |   float32 |       cuda |         59.00 μs |         32.276 μs |       1.769 μs | 0.002 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |      65536 |   float32 |       cuda |      2,841.03 μs |      1,049.979 μs |      57.553 μs | 0.072 |    0.00 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |      65536 |   float32 |       cuda |      2,855.00 μs |      1,723.219 μs |      94.455 μs | 0.073 |    0.00 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |      65536 |   float32 |       cuda |      2,416.60 μs |        923.426 μs |      50.616 μs | 0.062 |    0.01 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |      65536 |   float32 |       cuda |      2,359.65 μs |        363.950 μs |      19.949 μs | 0.060 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |      65536 |   float32 |       cuda |     15,502.00 μs |        310.140 μs |      17.000 μs |  1.00 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |      65536 |   float32 |       cuda |        654.83 μs |        106.789 μs |       5.853 μs |  0.04 |    0.00 |       No |
|            zeros_RawTensor_Torch |        zeros |      65536 |   float32 |       cuda |        723.47 μs |        142.328 μs |       7.801 μs |  0.05 |    0.00 |       No |
|               zeros_Tensor_Torch |        zeros |      65536 |   float32 |       cuda |        692.87 μs |         27.868 μs |       1.528 μs |  0.04 |    0.00 |       No |
|        zeros_RawTensor_Reference |        zeros |      65536 |   float32 |       cuda |      3,181.18 μs |        304.524 μs |      16.692 μs |  0.21 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |      65536 |   float32 |       cuda |      3,289.21 μs |        899.222 μs |      49.289 μs |  0.21 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |      65536 |   float32 |       cuda |     15,504.32 μs |        737.885 μs |      40.446 μs |  1.00 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |      65536 |   float32 |       cuda |        652.83 μs |        281.228 μs |      15.415 μs |  0.04 |    0.00 |       No |
|             ones_RawTensor_Torch |         ones |      65536 |   float32 |       cuda |        699.07 μs |        230.798 μs |      12.651 μs |  0.05 |    0.00 |       No |
|                ones_Tensor_Torch |         ones |      65536 |   float32 |       cuda |        665.67 μs |        135.365 μs |       7.420 μs |  0.04 |    0.00 |       No |
|         ones_RawTensor_Reference |         ones |      65536 |   float32 |       cuda |      4,884.99 μs |        503.488 μs |      27.598 μs |  0.32 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |      65536 |   float32 |       cuda |      4,981.63 μs |        644.254 μs |      35.314 μs |  0.32 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |      65536 |   float32 |       cuda |     15,458.59 μs |      1,400.930 μs |      76.790 μs |  1.00 |    0.00 |      Yes |
|                  rand_TorchSharp |         rand |      65536 |   float32 |       cuda |        678.00 μs |        325.654 μs |      17.850 μs |  0.04 |    0.00 |       No |
|             rand_RawTensor_Torch |         rand |      65536 |   float32 |       cuda |        723.23 μs |        324.678 μs |      17.797 μs |  0.05 |    0.00 |       No |
|                rand_Tensor_Torch |         rand |      65536 |   float32 |       cuda |        713.53 μs |         67.682 μs |       3.710 μs |  0.05 |    0.00 |       No |
|         rand_RawTensor_Reference |         rand |      65536 |   float32 |       cuda |     34,090.65 μs |        371.584 μs |      20.368 μs |  2.21 |    0.01 |       No |
|            rand_Tensor_Reference |         rand |      65536 |   float32 |       cuda |     34,023.61 μs |      2,468.289 μs |     135.295 μs |  2.20 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |      65536 |   float32 |       cuda |     15,492.31 μs |      1,692.962 μs |      92.797 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |      65536 |   float32 |       cuda |        770.13 μs |      3,897.504 μs |     213.635 μs |  0.05 |    0.01 |       No |
|         addition_RawTensor_Torch |     addition |      65536 |   float32 |       cuda |        659.17 μs |        485.805 μs |      26.629 μs |  0.04 |    0.00 |       No |
|            addition_Tensor_Torch |     addition |      65536 |   float32 |       cuda |        776.77 μs |         80.279 μs |       4.400 μs |  0.05 |    0.00 |       No |
|     addition_RawTensor_Reference |     addition |      65536 |   float32 |       cuda |     10,201.11 μs |      1,876.850 μs |     102.876 μs |  0.66 |    0.01 |       No |
|        addition_Tensor_Reference |     addition |      65536 |   float32 |       cuda |     10,172.71 μs |      2,261.391 μs |     123.954 μs |  0.66 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |      65536 |   float32 |       cuda |     15,445.19 μs |        797.592 μs |      43.719 μs |  1.00 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |      65536 |   float32 |       cuda |        785.87 μs |        291.399 μs |      15.973 μs |  0.05 |    0.00 |       No |
|        addScalar_RawTensor_Torch |    addScalar |      65536 |   float32 |       cuda |        842.40 μs |        166.018 μs |       9.100 μs |  0.05 |    0.00 |       No |
|           addScalar_Tensor_Torch |    addScalar |      65536 |   float32 |       cuda |      1,413.17 μs |      1,250.488 μs |      68.543 μs |  0.09 |    0.00 |       No |
|    addScalar_RawTensor_Reference |    addScalar |      65536 |   float32 |       cuda |      4,979.86 μs |        607.894 μs |      33.321 μs |  0.32 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |      65536 |   float32 |       cuda |     12,235.69 μs |      1,370.946 μs |      75.146 μs |  0.79 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |      65536 |   float32 |       cuda |     15,506.16 μs |        793.436 μs |      43.491 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |      65536 |   float32 |       cuda |        568.80 μs |        148.985 μs |       8.166 μs |  0.04 |    0.00 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |      65536 |   float32 |       cuda |        643.00 μs |        111.734 μs |       6.125 μs |  0.04 |    0.00 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |      65536 |   float32 |       cuda |      1,757.47 μs |        464.776 μs |      25.476 μs |  0.11 |    0.00 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |      65536 |   float32 |       cuda |     10,040.48 μs |      2,357.548 μs |     129.225 μs |  0.65 |    0.01 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |      65536 |   float32 |       cuda |     18,294.20 μs |      3,604.659 μs |     197.584 μs |  1.18 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |      65536 |   float32 |       cuda |     15,462.91 μs |        962.057 μs |      52.734 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |      65536 |   float32 |       cuda |        406.43 μs |        950.602 μs |      52.106 μs |  0.03 |    0.00 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |      65536 |   float32 |       cuda |        412.97 μs |        110.331 μs |       6.048 μs |  0.03 |    0.00 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |      65536 |   float32 |       cuda |        773.63 μs |         51.612 μs |       2.829 μs |  0.05 |    0.00 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |      65536 |   float32 |       cuda |      8,546.58 μs |        851.418 μs |      46.669 μs |  0.55 |    0.00 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |      65536 |   float32 |       cuda |      9,957.87 μs |        870.273 μs |      47.703 μs |  0.64 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |      65536 |   float32 |       cuda |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |      65536 |   float32 |       cuda |        513.37 μs |      1,753.876 μs |      96.136 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |      65536 |   float32 |       cuda |        247.83 μs |         58.389 μs |       3.201 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |      65536 |   float32 |       cuda |        276.70 μs |        106.190 μs |       5.821 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |      65536 |   float32 |       cuda |    927,500.70 μs |     53,320.793 μs |   2,922.693 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |      65536 |   float32 |       cuda |    917,603.53 μs |    168,418.789 μs |   9,231.602 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |      **65536** |   **float64** |        **cpu** |     **41,633.70 μs** |     **23,929.165 μs** |   **1,311.638 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |      65536 |   float64 |        cpu |         44.53 μs |         30.222 μs |       1.657 μs | 0.001 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |      65536 |   float64 |        cpu |      2,037.38 μs |        442.313 μs |      24.245 μs | 0.049 |    0.00 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |      65536 |   float64 |        cpu |      2,055.76 μs |        599.141 μs |      32.841 μs | 0.049 |    0.00 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |      65536 |   float64 |        cpu |      2,453.87 μs |        424.042 μs |      23.243 μs | 0.059 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |      65536 |   float64 |        cpu |      2,434.10 μs |        271.321 μs |      14.872 μs | 0.059 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |      65536 |   float64 |        cpu |     15,524.63 μs |      1,824.679 μs |     100.017 μs |  1.00 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |      65536 |   float64 |        cpu |      3,899.04 μs |      2,630.399 μs |     144.181 μs |  0.25 |    0.01 |       No |
|            zeros_RawTensor_Torch |        zeros |      65536 |   float64 |        cpu |      6,977.18 μs |      9,326.407 μs |     511.212 μs |  0.45 |    0.03 |       No |
|               zeros_Tensor_Torch |        zeros |      65536 |   float64 |        cpu |      6,843.38 μs |     11,904.263 μs |     652.513 μs |  0.44 |    0.04 |       No |
|        zeros_RawTensor_Reference |        zeros |      65536 |   float64 |        cpu |      4,071.43 μs |      1,019.800 μs |      55.899 μs |  0.26 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |      65536 |   float64 |        cpu |      4,054.23 μs |        202.297 μs |      11.089 μs |  0.26 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |      65536 |   float64 |        cpu |     15,478.88 μs |        546.910 μs |      29.978 μs |  1.00 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |      65536 |   float64 |        cpu |      4,235.99 μs |      8,438.496 μs |     462.542 μs |  0.27 |    0.03 |       No |
|             ones_RawTensor_Torch |         ones |      65536 |   float64 |        cpu |      7,108.21 μs |      1,145.741 μs |      62.802 μs |  0.46 |    0.00 |       No |
|                ones_Tensor_Torch |         ones |      65536 |   float64 |        cpu |      7,248.83 μs |      1,164.719 μs |      63.842 μs |  0.47 |    0.00 |       No |
|         ones_RawTensor_Reference |         ones |      65536 |   float64 |        cpu |      6,662.87 μs |        889.714 μs |      48.768 μs |  0.43 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |      65536 |   float64 |        cpu |      6,763.09 μs |        693.668 μs |      38.022 μs |  0.44 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |      65536 |   float64 |        cpu |     46,692.14 μs |      6,590.889 μs |     361.269 μs |  1.00 |    0.00 |      Yes |
|                  rand_TorchSharp |         rand |      65536 |   float64 |        cpu |     19,898.67 μs |      1,453.540 μs |      79.673 μs |  0.43 |    0.00 |       No |
|             rand_RawTensor_Torch |         rand |      65536 |   float64 |        cpu |     42,711.72 μs |     38,699.048 μs |   2,121.225 μs |  0.91 |    0.04 |       No |
|                rand_Tensor_Torch |         rand |      65536 |   float64 |        cpu |     42,641.21 μs |     15,414.973 μs |     844.947 μs |  0.91 |    0.02 |       No |
|         rand_RawTensor_Reference |         rand |      65536 |   float64 |        cpu |     35,951.74 μs |      2,874.835 μs |     157.579 μs |  0.77 |    0.01 |       No |
|            rand_Tensor_Reference |         rand |      65536 |   float64 |        cpu |     37,714.04 μs |      4,720.806 μs |     258.763 μs |  0.81 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |      65536 |   float64 |        cpu |     15,680.24 μs |      2,923.544 μs |     160.249 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |      65536 |   float64 |        cpu |      5,320.28 μs |      6,323.726 μs |     346.625 μs |  0.34 |    0.02 |       No |
|         addition_RawTensor_Torch |     addition |      65536 |   float64 |        cpu |      4,910.40 μs |      3,789.923 μs |     207.738 μs |  0.31 |    0.02 |       No |
|            addition_Tensor_Torch |     addition |      65536 |   float64 |        cpu |      5,126.72 μs |      4,422.716 μs |     242.424 μs |  0.33 |    0.01 |       No |
|     addition_RawTensor_Reference |     addition |      65536 |   float64 |        cpu |      8,637.06 μs |        819.284 μs |      44.908 μs |  0.55 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |      65536 |   float64 |        cpu |      9,439.84 μs |      3,755.415 μs |     205.847 μs |  0.60 |    0.02 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |      65536 |   float64 |        cpu |     15,590.53 μs |      1,729.336 μs |      94.791 μs |  1.00 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |      65536 |   float64 |        cpu |      5,142.97 μs |      2,336.146 μs |     128.052 μs |  0.33 |    0.01 |       No |
|        addScalar_RawTensor_Torch |    addScalar |      65536 |   float64 |        cpu |      5,303.07 μs |      1,000.810 μs |      54.858 μs |  0.34 |    0.01 |       No |
|           addScalar_Tensor_Torch |    addScalar |      65536 |   float64 |        cpu |      5,321.11 μs |      2,907.207 μs |     159.354 μs |  0.34 |    0.01 |       No |
|    addScalar_RawTensor_Reference |    addScalar |      65536 |   float64 |        cpu |      5,137.19 μs |        756.751 μs |      41.480 μs |  0.33 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |      65536 |   float64 |        cpu |     13,975.78 μs |      6,248.237 μs |     342.487 μs |  0.90 |    0.02 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |      65536 |   float64 |        cpu |     15,611.84 μs |      1,269.036 μs |      69.560 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |      65536 |   float64 |        cpu |      4,526.14 μs |      1,753.466 μs |      96.113 μs |  0.29 |    0.01 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |      65536 |   float64 |        cpu |      4,479.61 μs |      6,741.193 μs |     369.508 μs |  0.29 |    0.02 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |      65536 |   float64 |        cpu |      9,765.85 μs |      1,698.522 μs |      93.102 μs |  0.63 |    0.00 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |      65536 |   float64 |        cpu |      8,769.16 μs |      3,204.289 μs |     175.638 μs |  0.56 |    0.01 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |      65536 |   float64 |        cpu |     20,750.07 μs |      2,886.190 μs |     158.202 μs |  1.33 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |      65536 |   float64 |        cpu |     15,612.87 μs |        973.666 μs |      53.370 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |      65536 |   float64 |        cpu |      1,731.93 μs |        833.522 μs |      45.688 μs |  0.11 |    0.00 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |      65536 |   float64 |        cpu |      1,938.87 μs |      1,847.573 μs |     101.272 μs |  0.12 |    0.01 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |      65536 |   float64 |        cpu |      4,975.04 μs |      3,372.807 μs |     184.875 μs |  0.32 |    0.01 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |      65536 |   float64 |        cpu |     10,092.02 μs |      1,101.415 μs |      60.372 μs |  0.65 |    0.01 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |      65536 |   float64 |        cpu |      8,676.85 μs |        384.564 μs |      21.079 μs |  0.56 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |      65536 |   float64 |        cpu |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |      65536 |   float64 |        cpu |      2,488.25 μs |      1,588.191 μs |      87.054 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |      65536 |   float64 |        cpu |      2,330.29 μs |      3,191.793 μs |     174.953 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |      65536 |   float64 |        cpu |      2,176.36 μs |      2,339.041 μs |     128.211 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |      65536 |   float64 |        cpu |    972,867.43 μs |     60,405.100 μs |   3,311.007 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |      65536 |   float64 |        cpu |    956,921.00 μs |     41,191.474 μs |   2,257.844 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |      **65536** |   **float64** |       **cuda** |     **46,720.92 μs** |      **7,078.476 μs** |     **387.995 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |      65536 |   float64 |       cuda |         54.37 μs |         25.822 μs |       1.415 μs | 0.001 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |      65536 |   float64 |       cuda |      3,970.03 μs |      1,322.772 μs |      72.506 μs | 0.085 |    0.00 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |      65536 |   float64 |       cuda |      4,002.93 μs |      2,290.558 μs |     125.553 μs | 0.086 |    0.00 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |      65536 |   float64 |       cuda |      2,493.99 μs |        115.838 μs |       6.349 μs | 0.053 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |      65536 |   float64 |       cuda |      2,492.61 μs |        798.459 μs |      43.766 μs | 0.053 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |      65536 |   float64 |       cuda |     15,454.93 μs |      1,305.411 μs |      71.554 μs |  1.00 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |      65536 |   float64 |       cuda |        658.17 μs |         92.313 μs |       5.060 μs |  0.04 |    0.00 |       No |
|            zeros_RawTensor_Torch |        zeros |      65536 |   float64 |       cuda |        690.93 μs |        124.343 μs |       6.816 μs |  0.04 |    0.00 |       No |
|               zeros_Tensor_Torch |        zeros |      65536 |   float64 |       cuda |        695.90 μs |         45.900 μs |       2.516 μs |  0.05 |    0.00 |       No |
|        zeros_RawTensor_Reference |        zeros |      65536 |   float64 |       cuda |      4,008.30 μs |        943.130 μs |      51.696 μs |  0.26 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |      65536 |   float64 |       cuda |      4,046.88 μs |        666.705 μs |      36.544 μs |  0.26 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |      65536 |   float64 |       cuda |     15,490.65 μs |        625.803 μs |      34.302 μs |  1.00 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |      65536 |   float64 |       cuda |        623.13 μs |        101.746 μs |       5.577 μs |  0.04 |    0.00 |       No |
|             ones_RawTensor_Torch |         ones |      65536 |   float64 |       cuda |        664.33 μs |        216.573 μs |      11.871 μs |  0.04 |    0.00 |       No |
|                ones_Tensor_Torch |         ones |      65536 |   float64 |       cuda |        684.77 μs |         89.994 μs |       4.933 μs |  0.04 |    0.00 |       No |
|         ones_RawTensor_Reference |         ones |      65536 |   float64 |       cuda |      6,727.44 μs |      1,326.120 μs |      72.689 μs |  0.43 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |      65536 |   float64 |       cuda |      6,742.88 μs |      1,287.093 μs |      70.550 μs |  0.44 |    0.01 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |      65536 |   float64 |       cuda |     15,488.60 μs |      1,467.465 μs |      80.437 μs |  1.00 |    0.00 |      Yes |
|                  rand_TorchSharp |         rand |      65536 |   float64 |       cuda |        666.17 μs |        228.392 μs |      12.519 μs |  0.04 |    0.00 |       No |
|             rand_RawTensor_Torch |         rand |      65536 |   float64 |       cuda |        739.53 μs |        344.832 μs |      18.901 μs |  0.05 |    0.00 |       No |
|                rand_Tensor_Torch |         rand |      65536 |   float64 |       cuda |        719.53 μs |        391.430 μs |      21.456 μs |  0.05 |    0.00 |       No |
|         rand_RawTensor_Reference |         rand |      65536 |   float64 |       cuda |     35,696.95 μs |      9,431.979 μs |     516.999 μs |  2.30 |    0.05 |       No |
|            rand_Tensor_Reference |         rand |      65536 |   float64 |       cuda |     36,962.83 μs |      1,256.649 μs |      68.881 μs |  2.39 |    0.02 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |      65536 |   float64 |       cuda |     15,466.17 μs |      1,379.355 μs |      75.607 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |      65536 |   float64 |       cuda |        590.03 μs |        267.190 μs |      14.646 μs |  0.04 |    0.00 |       No |
|         addition_RawTensor_Torch |     addition |      65536 |   float64 |       cuda |        628.40 μs |        124.979 μs |       6.851 μs |  0.04 |    0.00 |       No |
|            addition_Tensor_Torch |     addition |      65536 |   float64 |       cuda |        745.47 μs |         97.537 μs |       5.346 μs |  0.05 |    0.00 |       No |
|     addition_RawTensor_Reference |     addition |      65536 |   float64 |       cuda |      9,350.40 μs |        656.814 μs |      36.002 μs |  0.60 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |      65536 |   float64 |       cuda |      9,420.37 μs |        757.383 μs |      41.515 μs |  0.61 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |      65536 |   float64 |       cuda |     15,472.96 μs |      1,494.828 μs |      81.937 μs |  1.00 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |      65536 |   float64 |       cuda |        771.73 μs |        113.644 μs |       6.229 μs |  0.05 |    0.00 |       No |
|        addScalar_RawTensor_Torch |    addScalar |      65536 |   float64 |       cuda |        842.27 μs |        252.689 μs |      13.851 μs |  0.05 |    0.00 |       No |
|           addScalar_Tensor_Torch |    addScalar |      65536 |   float64 |       cuda |      1,355.53 μs |        205.324 μs |      11.254 μs |  0.09 |    0.00 |       No |
|    addScalar_RawTensor_Reference |    addScalar |      65536 |   float64 |       cuda |      5,111.08 μs |         36.842 μs |       2.019 μs |  0.33 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |      65536 |   float64 |       cuda |     13,870.69 μs |        199.358 μs |      10.928 μs |  0.90 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |      65536 |   float64 |       cuda |     15,522.90 μs |        752.195 μs |      41.230 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |      65536 |   float64 |       cuda |        608.37 μs |        971.084 μs |      53.228 μs |  0.04 |    0.00 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |      65536 |   float64 |       cuda |        607.67 μs |        120.827 μs |       6.623 μs |  0.04 |    0.00 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |      65536 |   float64 |       cuda |      1,782.13 μs |        952.569 μs |      52.214 μs |  0.11 |    0.00 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |      65536 |   float64 |       cuda |      9,259.07 μs |      1,398.339 μs |      76.648 μs |  0.60 |    0.01 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |      65536 |   float64 |       cuda |     20,455.92 μs |      1,503.142 μs |      82.392 μs |  1.32 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |      65536 |   float64 |       cuda |     15,482.31 μs |      1,275.630 μs |      69.922 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |      65536 |   float64 |       cuda |        363.97 μs |        106.509 μs |       5.838 μs |  0.02 |    0.00 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |      65536 |   float64 |       cuda |        417.83 μs |        240.494 μs |      13.182 μs |  0.03 |    0.00 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |      65536 |   float64 |       cuda |        767.77 μs |        243.336 μs |      13.338 μs |  0.05 |    0.00 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |      65536 |   float64 |       cuda |      9,988.09 μs |      1,487.265 μs |      81.522 μs |  0.65 |    0.01 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |      65536 |   float64 |       cuda |      9,327.93 μs |        332.500 μs |      18.225 μs |  0.60 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |      65536 |   float64 |       cuda |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |      65536 |   float64 |       cuda |         97.60 μs |        382.610 μs |      20.972 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |      65536 |   float64 |       cuda |         96.40 μs |        341.401 μs |      18.713 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |      65536 |   float64 |       cuda |        124.60 μs |        661.669 μs |      36.268 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |      65536 |   float64 |       cuda |    966,341.73 μs |     14,231.153 μs |     780.058 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |      65536 |   float64 |       cuda |    964,324.53 μs |     69,072.963 μs |   3,786.122 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |      **65536** |     **int32** |        **cpu** |     **31,081.50 μs** |      **2,941.665 μs** |     **161.243 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |      65536 |     int32 |        cpu |         40.79 μs |          7.465 μs |       0.409 μs | 0.001 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |      65536 |     int32 |        cpu |      1,607.01 μs |        202.572 μs |      11.104 μs | 0.052 |    0.00 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |      65536 |     int32 |        cpu |      1,605.99 μs |        438.822 μs |      24.053 μs | 0.052 |    0.00 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |      65536 |     int32 |        cpu |      2,213.02 μs |        921.492 μs |      50.510 μs | 0.071 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |      65536 |     int32 |        cpu |      2,167.57 μs |        708.532 μs |      38.837 μs | 0.070 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |      65536 |     int32 |        cpu |     15,458.43 μs |      1,171.607 μs |      64.220 μs |  1.00 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |      65536 |     int32 |        cpu |      3,923.33 μs |      1,793.649 μs |      98.316 μs |  0.25 |    0.01 |       No |
|            zeros_RawTensor_Torch |        zeros |      65536 |     int32 |        cpu |      3,952.61 μs |      4,774.813 μs |     261.724 μs |  0.26 |    0.02 |       No |
|               zeros_Tensor_Torch |        zeros |      65536 |     int32 |        cpu |      3,802.51 μs |      2,956.480 μs |     162.055 μs |  0.25 |    0.01 |       No |
|        zeros_RawTensor_Reference |        zeros |      65536 |     int32 |        cpu |      3,055.51 μs |        170.510 μs |       9.346 μs |  0.20 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |      65536 |     int32 |        cpu |      3,082.98 μs |        218.335 μs |      11.968 μs |  0.20 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |      65536 |     int32 |        cpu |     15,490.82 μs |        886.304 μs |      48.581 μs |  1.00 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |      65536 |     int32 |        cpu |      3,927.33 μs |      1,999.536 μs |     109.601 μs |  0.25 |    0.01 |       No |
|             ones_RawTensor_Torch |         ones |      65536 |     int32 |        cpu |      4,034.24 μs |      1,579.156 μs |      86.559 μs |  0.26 |    0.01 |       No |
|                ones_Tensor_Torch |         ones |      65536 |     int32 |        cpu |      3,857.85 μs |      2,925.553 μs |     160.359 μs |  0.25 |    0.01 |       No |
|         ones_RawTensor_Reference |         ones |      65536 |     int32 |        cpu |      4,765.25 μs |        349.680 μs |      19.167 μs |  0.31 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |      65536 |     int32 |        cpu |      4,733.73 μs |        250.489 μs |      13.730 μs |  0.31 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |      65536 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |      Yes |
|                  rand_TorchSharp |         rand |      65536 |     int32 |        cpu |     32,416.12 μs |      5,528.694 μs |     303.046 μs |     ? |       ? |       No |
|             rand_RawTensor_Torch |         rand |      65536 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |       No |
|                rand_Tensor_Torch |         rand |      65536 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |       No |
|         rand_RawTensor_Reference |         rand |      65536 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |       No |
|            rand_Tensor_Reference |         rand |      65536 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |      65536 |     int32 |        cpu |     15,506.16 μs |      1,831.982 μs |     100.417 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |      65536 |     int32 |        cpu |      4,529.56 μs |      2,035.560 μs |     111.576 μs |  0.29 |    0.01 |       No |
|         addition_RawTensor_Torch |     addition |      65536 |     int32 |        cpu |      4,582.77 μs |      2,039.566 μs |     111.796 μs |  0.30 |    0.01 |       No |
|            addition_Tensor_Torch |     addition |      65536 |     int32 |        cpu |      4,764.40 μs |      3,959.822 μs |     217.051 μs |  0.31 |    0.01 |       No |
|     addition_RawTensor_Reference |     addition |      65536 |     int32 |        cpu |      8,451.58 μs |      1,754.985 μs |      96.197 μs |  0.55 |    0.01 |       No |
|        addition_Tensor_Reference |     addition |      65536 |     int32 |        cpu |      9,169.03 μs |        444.335 μs |      24.356 μs |  0.59 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |      65536 |     int32 |        cpu |     15,563.70 μs |      2,559.004 μs |     140.268 μs |  1.00 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |      65536 |     int32 |        cpu |      4,667.87 μs |      1,998.769 μs |     109.559 μs |  0.30 |    0.01 |       No |
|        addScalar_RawTensor_Torch |    addScalar |      65536 |     int32 |        cpu |      4,999.28 μs |      3,246.652 μs |     177.960 μs |  0.32 |    0.01 |       No |
|           addScalar_Tensor_Torch |    addScalar |      65536 |     int32 |        cpu |      8,768.24 μs |      7,483.249 μs |     410.182 μs |  0.56 |    0.03 |       No |
|    addScalar_RawTensor_Reference |    addScalar |      65536 |     int32 |        cpu |      5,102.61 μs |        311.625 μs |      17.081 μs |  0.33 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |      65536 |     int32 |        cpu |    119,085.63 μs |    130,977.589 μs |   7,179.324 μs |  7.65 |    0.48 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |      65536 |     int32 |        cpu |     15,542.43 μs |      1,153.386 μs |      63.221 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |      65536 |     int32 |        cpu |      4,400.67 μs |      1,719.400 μs |      94.246 μs |  0.28 |    0.01 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |      65536 |     int32 |        cpu |      4,492.64 μs |      1,054.964 μs |      57.826 μs |  0.29 |    0.00 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |      65536 |     int32 |        cpu |      9,775.01 μs |     10,096.680 μs |     553.433 μs |  0.63 |    0.03 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |      65536 |     int32 |        cpu |      8,414.42 μs |      1,158.614 μs |      63.508 μs |  0.54 |    0.01 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |      65536 |     int32 |        cpu |    257,658.33 μs |    174,232.382 μs |   9,550.265 μs | 16.58 |    0.66 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |      65536 |     int32 |        cpu |     15,567.44 μs |      1,892.126 μs |     103.714 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |      65536 |     int32 |        cpu |      1,671.38 μs |      2,030.207 μs |     111.283 μs |  0.11 |    0.01 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |      65536 |     int32 |        cpu |      1,785.33 μs |        880.895 μs |      48.285 μs |  0.11 |    0.00 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |      65536 |     int32 |        cpu |      4,575.83 μs |      2,455.038 μs |     134.569 μs |  0.29 |    0.01 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |      65536 |     int32 |        cpu |      8,497.97 μs |        361.917 μs |      19.838 μs |  0.55 |    0.00 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |      65536 |     int32 |        cpu |      9,067.92 μs |        376.899 μs |      20.659 μs |  0.58 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |      65536 |     int32 |        cpu |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |      65536 |     int32 |        cpu |     33,030.95 μs |        506.860 μs |      27.783 μs |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |      65536 |     int32 |        cpu |     33,250.56 μs |      2,971.803 μs |     162.895 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |      65536 |     int32 |        cpu |     33,267.60 μs |      2,305.600 μs |     126.378 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |      65536 |     int32 |        cpu |    927,936.27 μs |     41,638.793 μs |   2,282.363 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |      65536 |     int32 |        cpu |    919,296.63 μs |    244,476.280 μs |  13,400.570 μs |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|              **fromCpuData_PyTorch** |  **fromCpuData** |      **65536** |     **int32** |       **cuda** |     **30,946.21 μs** |      **1,185.035 μs** |      **64.956 μs** | **1.000** |    **0.00** |      **Yes** |
|           fromCpuData_TorchSharp |  fromCpuData |      65536 |     int32 |       cuda |         56.50 μs |         76.254 μs |       4.180 μs | 0.002 |    0.00 |       No |
|      fromCpuData_RawTensor_Torch |  fromCpuData |      65536 |     int32 |       cuda |      2,727.33 μs |      1,245.470 μs |      68.268 μs | 0.088 |    0.00 |       No |
|         fromCpuData_Tensor_Torch |  fromCpuData |      65536 |     int32 |       cuda |      2,669.67 μs |        466.534 μs |      25.572 μs | 0.086 |    0.00 |       No |
|  fromCpuData_RawTensor_Reference |  fromCpuData |      65536 |     int32 |       cuda |      2,224.48 μs |      1,017.415 μs |      55.768 μs | 0.072 |    0.00 |       No |
|     fromCpuData_Tensor_Reference |  fromCpuData |      65536 |     int32 |       cuda |      2,204.16 μs |        224.955 μs |      12.331 μs | 0.071 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                    zeros_PyTorch |        zeros |      65536 |     int32 |       cuda |     15,476.59 μs |      1,364.021 μs |      74.767 μs |  1.00 |    0.00 |      Yes |
|                 zeros_TorchSharp |        zeros |      65536 |     int32 |       cuda |        645.13 μs |         37.492 μs |       2.055 μs |  0.04 |    0.00 |       No |
|            zeros_RawTensor_Torch |        zeros |      65536 |     int32 |       cuda |        694.87 μs |        110.737 μs |       6.070 μs |  0.04 |    0.00 |       No |
|               zeros_Tensor_Torch |        zeros |      65536 |     int32 |       cuda |        692.20 μs |        241.982 μs |      13.264 μs |  0.04 |    0.00 |       No |
|        zeros_RawTensor_Reference |        zeros |      65536 |     int32 |       cuda |      3,075.33 μs |         89.011 μs |       4.879 μs |  0.20 |    0.00 |       No |
|           zeros_Tensor_Reference |        zeros |      65536 |     int32 |       cuda |      3,085.42 μs |        226.418 μs |      12.411 μs |  0.20 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     ones_PyTorch |         ones |      65536 |     int32 |       cuda |     15,527.34 μs |      1,166.368 μs |      63.933 μs |  1.00 |    0.00 |      Yes |
|                  ones_TorchSharp |         ones |      65536 |     int32 |       cuda |        633.37 μs |        300.719 μs |      16.483 μs |  0.04 |    0.00 |       No |
|             ones_RawTensor_Torch |         ones |      65536 |     int32 |       cuda |        687.43 μs |        463.980 μs |      25.432 μs |  0.04 |    0.00 |       No |
|                ones_Tensor_Torch |         ones |      65536 |     int32 |       cuda |        698.27 μs |         82.104 μs |       4.500 μs |  0.04 |    0.00 |       No |
|         ones_RawTensor_Reference |         ones |      65536 |     int32 |       cuda |      4,762.00 μs |        128.832 μs |       7.062 μs |  0.31 |    0.00 |       No |
|            ones_Tensor_Reference |         ones |      65536 |     int32 |       cuda |      4,777.38 μs |        548.587 μs |      30.070 μs |  0.31 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                     rand_PyTorch |         rand |      65536 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |      Yes |
|                  rand_TorchSharp |         rand |      65536 |     int32 |       cuda |        662.73 μs |        317.065 μs |      17.379 μs |     ? |       ? |       No |
|             rand_RawTensor_Torch |         rand |      65536 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|                rand_Tensor_Torch |         rand |      65536 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|         rand_RawTensor_Reference |         rand |      65536 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|            rand_Tensor_Reference |         rand |      65536 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                 addition_PyTorch |     addition |      65536 |     int32 |       cuda |     15,472.14 μs |      1,250.929 μs |      68.568 μs |  1.00 |    0.00 |      Yes |
|              addition_TorchSharp |     addition |      65536 |     int32 |       cuda |      1,157.60 μs |      7,333.869 μs |     401.994 μs |  0.07 |    0.03 |       No |
|         addition_RawTensor_Torch |     addition |      65536 |     int32 |       cuda |        630.23 μs |        190.438 μs |      10.439 μs |  0.04 |    0.00 |       No |
|            addition_Tensor_Torch |     addition |      65536 |     int32 |       cuda |        800.37 μs |        872.512 μs |      47.825 μs |  0.05 |    0.00 |       No |
|     addition_RawTensor_Reference |     addition |      65536 |     int32 |       cuda |      8,310.89 μs |        626.762 μs |      34.355 μs |  0.54 |    0.00 |       No |
|        addition_Tensor_Reference |     addition |      65536 |     int32 |       cuda |      9,129.60 μs |        434.270 μs |      23.804 μs |  0.59 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                addScalar_PyTorch |    addScalar |      65536 |     int32 |       cuda |     15,523.56 μs |      1,076.788 μs |      59.022 μs |  1.00 |    0.00 |      Yes |
|             addScalar_TorchSharp |    addScalar |      65536 |     int32 |       cuda |        756.07 μs |        309.769 μs |      16.979 μs |  0.05 |    0.00 |       No |
|        addScalar_RawTensor_Torch |    addScalar |      65536 |     int32 |       cuda |        862.03 μs |         77.344 μs |       4.239 μs |  0.06 |    0.00 |       No |
|           addScalar_Tensor_Torch |    addScalar |      65536 |     int32 |       cuda |      2,455.93 μs |        289.002 μs |      15.841 μs |  0.16 |    0.00 |       No |
|    addScalar_RawTensor_Reference |    addScalar |      65536 |     int32 |       cuda |      5,109.50 μs |        254.904 μs |      13.972 μs |  0.33 |    0.00 |       No |
|       addScalar_Tensor_Reference |    addScalar |      65536 |     int32 |       cuda |    116,333.83 μs |     34,721.098 μs |   1,903.181 μs |  7.49 |    0.10 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|             addWithAlpha_PyTorch | addWithAlpha |      65536 |     int32 |       cuda |     15,500.14 μs |      1,279.903 μs |      70.156 μs |  1.00 |    0.00 |      Yes |
|          addWithAlpha_TorchSharp | addWithAlpha |      65536 |     int32 |       cuda |        559.83 μs |        150.047 μs |       8.225 μs |  0.04 |    0.00 |       No |
|     addWithAlpha_RawTensor_Torch | addWithAlpha |      65536 |     int32 |       cuda |        652.67 μs |         47.234 μs |       2.589 μs |  0.04 |    0.00 |       No |
|        addWithAlpha_Tensor_Torch | addWithAlpha |      65536 |     int32 |       cuda |      1,741.90 μs |        135.508 μs |       7.428 μs |  0.11 |    0.00 |       No |
| addWithAlpha_RawTensor_Reference | addWithAlpha |      65536 |     int32 |       cuda |      8,323.34 μs |        256.720 μs |      14.072 μs |  0.54 |    0.00 |       No |
|    addWithAlpha_Tensor_Reference | addWithAlpha |      65536 |     int32 |       cuda |    252,919.87 μs |     29,769.305 μs |   1,631.756 μs | 16.32 |    0.14 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|               addInPlace_PyTorch |   addInPlace |      65536 |     int32 |       cuda |     15,494.49 μs |      1,281.047 μs |      70.219 μs |  1.00 |    0.00 |      Yes |
|            addInPlace_TorchSharp |   addInPlace |      65536 |     int32 |       cuda |        381.20 μs |         69.685 μs |       3.820 μs |  0.02 |    0.00 |       No |
|       addInPlace_RawTensor_Torch |   addInPlace |      65536 |     int32 |       cuda |        419.90 μs |        101.232 μs |       5.549 μs |  0.03 |    0.00 |       No |
|          addInPlace_Tensor_Torch |   addInPlace |      65536 |     int32 |       cuda |        764.67 μs |        142.749 μs |       7.825 μs |  0.05 |    0.00 |       No |
|   addInPlace_RawTensor_Reference |   addInPlace |      65536 |     int32 |       cuda |      8,590.73 μs |      3,679.955 μs |     201.711 μs |  0.55 |    0.01 |       No |
|      addInPlace_Tensor_Reference |   addInPlace |      65536 |     int32 |       cuda |      9,143.42 μs |        583.807 μs |      32.000 μs |  0.59 |    0.00 |       No |
|                                  |              |            |           |            |                  |                   |                |       |         |          |
|                   matmul_PyTorch |       matmul |      65536 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |      Yes |
|                matmul_TorchSharp |       matmul |      65536 |     int32 |       cuda |               NA |                NA |             NA |     ? |       ? |       No |
|           matmul_RawTensor_Torch |       matmul |      65536 |     int32 |       cuda |        432.90 μs |        111.017 μs |       6.085 μs |     ? |       ? |       No |
|              matmul_Tensor_Torch |       matmul |      65536 |     int32 |       cuda |        467.87 μs |        180.201 μs |       9.877 μs |     ? |       ? |       No |
|       matmul_RawTensor_Reference |       matmul |      65536 |     int32 |       cuda |    917,716.13 μs |     16,393.812 μs |     898.600 μs |     ? |       ? |       No |
|          matmul_Tensor_Reference |       matmul |      65536 |     int32 |       cuda |    904,911.87 μs |    287,989.758 μs |  15,785.690 μs |     ? |       ? |       No |

Benchmarks with issues:
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=float32, deviceName=cpu]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=float32, deviceName=cuda]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=float64, deviceName=cpu]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=float64, deviceName=cuda]
  BasicTensorOps.rand_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_RawTensor_Torch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_Tensor_Torch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_RawTensor_Reference: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_Tensor_Reference: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.rand_RawTensor_Torch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.rand_Tensor_Torch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.rand_RawTensor_Reference: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.rand_Tensor_Reference: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.matmul_TorchSharp: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=16, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=float32, deviceName=cpu]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=float32, deviceName=cuda]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=float64, deviceName=cpu]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=float64, deviceName=cuda]
  BasicTensorOps.rand_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_RawTensor_Torch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_Tensor_Torch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_RawTensor_Reference: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_Tensor_Reference: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.rand_RawTensor_Torch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.rand_Tensor_Torch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.rand_RawTensor_Reference: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.rand_Tensor_Reference: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.matmul_TorchSharp: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=2048, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=float32, deviceName=cpu]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=float32, deviceName=cuda]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=float64, deviceName=cpu]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=float64, deviceName=cuda]
  BasicTensorOps.rand_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_RawTensor_Torch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_Tensor_Torch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_RawTensor_Reference: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_Tensor_Reference: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=int32, deviceName=cpu]
  BasicTensorOps.rand_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.rand_RawTensor_Torch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.rand_Tensor_Torch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.rand_RawTensor_Reference: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.rand_Tensor_Reference: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.matmul_PyTorch: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=int32, deviceName=cuda]
  BasicTensorOps.matmul_TorchSharp: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [tensorSize=65536, dtypeName=int32, deviceName=cuda]
