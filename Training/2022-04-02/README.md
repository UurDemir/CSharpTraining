# Performance

## References
### Reflaction Example
Owner	: Nick Chapsas
Youtube	: https://www.youtube.com/watch?v=er9nD-usM1A&ab_channel=NickChapsas

## Benchmark Results
### Class and Struct

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|             Method |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
|------------------- |----------:|----------:|----------:|-------:|----------:|
|  RunArrayWithClass | 78.097 ns | 0.9645 ns | 0.9022 ns | 0.0205 |     344 B |
| RunArrayWithStruct |  8.159 ns | 0.0714 ns | 0.0633 ns | 0.0062 |     104 B |
|       RunWithClass | 61.305 ns | 1.0243 ns | 0.9581 ns | 0.0143 |     240 B |
|      RunWithStruct |  2.125 ns | 0.0210 ns | 0.0186 ns |      - |         - |

### String
#### String With Less Text
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|                                  Method |       Mean |      Error |     StdDev |  Gen 0 | Allocated |
|---------------------------------------- |-----------:|-----------:|-----------:|-------:|----------:|
|                       StringWithClassic |   2.220 ns |  0.0660 ns |  0.1102 ns |      - |         - |
|                        StringWithFormat | 653.502 ns |  7.8895 ns |  7.3799 ns | 0.0620 |   1,040 B |
|                 StringWithInterpolation |   2.082 ns |  0.0529 ns |  0.0495 ns |      - |         - |
|                       StringWithBuilder | 680.490 ns | 12.4439 ns | 18.6254 ns | 0.2670 |   4,480 B |
|         StringWithBuilderSingleInstance | 288.691 ns |  5.7204 ns |  5.3509 ns | 0.0896 |   1,504 B |
|               StringWithBuilderCapacity | 294.190 ns |  4.7234 ns |  4.4182 ns | 0.1621 |   2,720 B |
| StringWithBuilderSingleInstanceCapacity | 231.149 ns |  4.5154 ns |  6.7584 ns | 0.0720 |   1,208 B |

#### String With More Text
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|                    Method |     Mean |   Error |   StdDev |  Gen 0 |  Gen 1 | Allocated |
|-------------------------- |---------:|--------:|---------:|-------:|-------:|----------:|
|         StringWithClassic | 137.4 ns | 2.22 ns |  1.97 ns | 0.1299 |      - |      2 KB |
|          StringWithFormat | 488.9 ns | 9.69 ns | 15.36 ns | 0.1678 |      - |      3 KB |
|   StringWithInterpolation | 136.3 ns | 2.48 ns |  2.32 ns | 0.1299 |      - |      2 KB |
|         StringWithBuilder | 184.9 ns | 3.27 ns |  3.05 ns | 0.0749 | 0.0002 |      1 KB |
| StringWithBuilderCapacity | 120.1 ns | 1.85 ns |  1.54 ns | 0.0811 | 0.0002 |      1 KB |

#### String With Less Text More Repeat
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|                                  Method |       Mean |      Error |     StdDev |    Gen 0 |   Allocated |
|---------------------------------------- |-----------:|-----------:|-----------:|---------:|------------:|
|                       StringWithClassic |   2.245 μs |  0.0125 μs |  0.0104 μs |        - |           - |
|                        StringWithFormat | 648.989 μs | 11.4332 μs | 10.6946 μs |  61.5234 | 1,040,001 B |
|                 StringWithInterpolation |   2.264 μs |  0.0290 μs |  0.0298 μs |        - |           - |
|                       StringWithBuilder | 678.174 μs | 12.7948 μs | 12.5662 μs | 267.5781 | 4,480,001 B |
|         StringWithBuilderSingleInstance | 224.593 μs |  4.4063 μs |  5.5726 μs |  62.0117 | 1,040,464 B |
|               StringWithBuilderCapacity | 294.015 μs |  5.8705 μs |  8.2297 μs | 162.5977 | 2,720,000 B |
| StringWithBuilderSingleInstanceCapacity | 212.015 μs |  4.2075 μs |  4.6766 μs |  62.0117 | 1,040,168 B |

#### String With More Text More Repeat
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|                    Method |         Mean |       Error |      StdDev |       Gen 0 |       Gen 1 |       Gen 2 |    Allocated |
|-------------------------- |-------------:|------------:|------------:|------------:|------------:|------------:|-------------:|
|         StringWithClassic | 105,046.2 μs | 2,067.45 μs | 2,123.12 μs | 525000.0000 | 520200.0000 | 520200.0000 | 1,758,413 KB |
|          StringWithFormat | 104,767.3 μs | 1,662.87 μs | 1,474.09 μs | 525000.0000 | 520800.0000 | 520200.0000 | 1,759,039 KB |
|   StringWithInterpolation | 104,363.0 μs | 1,222.49 μs | 1,020.84 μs | 525000.0000 | 520200.0000 | 520200.0000 | 1,758,414 KB |
|         StringWithBuilder |     202.4 μs |     3.81 μs |     3.75 μs |    111.0840 |    111.0840 |    111.0840 |       714 KB |
| StringWithBuilderCapacity |     137.9 μs |     0.78 μs |     0.69 μs |    283.9355 |    283.6914 |    283.6914 |     1,232 KB |

#### String Replace

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|                     Method |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
|--------------------------- |-----------:|----------:|----------:|-------:|----------:|
| StringSubstringWithClassic | 6,582.2 ns | 130.67 ns | 174.44 ns | 2.8687 |  48,000 B |
|    StringSubstringWithSpan |   242.7 ns |   3.75 ns |   3.51 ns | 0.0100 |     168 B |

### List And Array Benchmark
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|                               Method |        Mean |       Error |      StdDev |    Gen 0 |  Gen 1 |   Allocated |
|------------------------------------- |------------:|------------:|------------:|---------:|-------:|------------:|
|                              ListAdd |  1,063.3 ns |    20.95 ns |    39.34 ns |   0.5016 | 0.0095 |     8,424 B |
|                         ListAddRange |  4,943.8 ns |    79.86 ns |    88.77 ns |   0.5035 | 0.0076 |     8,464 B |
|                  ListWithCapacityAdd |    791.0 ns |     6.56 ns |     5.81 ns |   0.2422 | 0.0029 |     4,056 B |
|             ListWithCapacityAddRange |  4,947.5 ns |    94.32 ns |    88.23 ns |   0.2441 |      - |     4,096 B |
|                       SharedArrayAdd |    242.2 ns |     4.21 ns |     3.94 ns |        - |      - |           - |
|                 ArrayWithCapacityAdd |    313.6 ns |     6.16 ns |     7.34 ns |   0.2403 |      - |     4,024 B |
| ArrayWithoutCapacityIncreaseByOneAdd | 71,014.4 ns | 1,305.07 ns | 1,156.91 ns | 121.0938 | 1.3428 | 2,027,896 B |
|              ArrayWithoutCapacityAdd |  1,017.8 ns |    16.24 ns |    15.19 ns |   0.4997 | 0.0019 |     8,392 B |


### Loops
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|           Method |       Mean |    Error |   StdDev |  Gen 0 |  Gen 1 | Allocated |
|----------------- |-----------:|---------:|---------:|-------:|-------:|----------:|
|           ForInt | 1,127.6 ns | 22.48 ns | 32.95 ns |      - |      - |         - |
|       ForeachInt |   660.7 ns | 11.36 ns | 10.07 ns |      - |      - |         - |
|         ForPoint | 1,319.8 ns |  1.64 ns |  1.37 ns |      - |      - |         - |
|     ForeachPoint | 1,127.5 ns |  6.37 ns |  5.65 ns |      - |      - |         - |
|        ForPerson | 1,102.1 ns |  7.95 ns |  7.44 ns |      - |      - |         - |
|    ForeachPerson |   659.2 ns |  6.94 ns |  6.49 ns |      - |      - |         - |
|        ForIntAdd | 1,958.7 ns | 25.89 ns | 22.95 ns | 0.2403 |      - |   4,056 B |
|    ForeachIntAdd | 1,252.7 ns |  9.17 ns |  8.57 ns | 0.2422 | 0.0019 |   4,056 B |
|      ForPointAdd | 2,246.7 ns | 13.68 ns | 12.80 ns | 0.4807 | 0.0114 |   8,056 B |
|  ForeachPointAdd | 2,211.1 ns | 26.64 ns | 24.92 ns | 0.4807 | 0.0114 |   8,056 B |
|     ForPersonAdd | 3,873.9 ns | 27.70 ns | 24.55 ns | 0.4807 | 0.0076 |   8,056 B |
| ForeachPersonAdd | 3,147.1 ns | 21.36 ns | 17.84 ns | 0.4807 | 0.0114 |   8,056 B |

### Memory
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|             Method |         Mean |        Error |       StdDev |  Gen 0 | Allocated |
|------------------- |-------------:|-------------:|-------------:|-------:|----------:|
|            WithNew |     642.2 ns |     12.86 ns |     24.79 ns | 0.4787 |   8,024 B |
|     WithStackAlloc |     609.6 ns |     11.99 ns |     11.21 ns |      - |         - |
| WithStackAllocSpan |     533.7 ns |     10.19 ns |      9.53 ns |      - |         - |
|     RunColumnFirst | 993,657.3 ns | 13,662.27 ns | 12,779.70 ns |      - |       1 B |
|        RunRowFirst | 562,852.4 ns |  6,983.00 ns |  6,190.25 ns |      - |         - |

### Method
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|                                                Method |      Mean |     Error |    StdDev | Allocated |
|------------------------------------------------------ |----------:|----------:|----------:|----------:|
|                                  MethodWithParameters | 35.272 ns | 0.6275 ns | 0.5870 ns |         - |
|                                       MethodWithClass | 35.259 ns | 0.5565 ns | 0.5205 ns |         - |
|                                     MethodWithNothing |  8.490 ns | 0.1648 ns | 0.1461 ns |         - |
|                          MethodWithAggressiveInlining |  7.485 ns | 0.0764 ns | 0.0638 ns |         - |
|                      MethodWithAggressiveOptimization |  8.415 ns | 0.0504 ns | 0.0447 ns |         - |
| MethodWithAggressiveOptimizationAndAggressiveInlining |  7.474 ns | 0.0211 ns | 0.0187 ns |         - |

### Reflaction

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.201
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|                         Method |      Mean |     Error |    StdDev |
|------------------------------- |----------:|----------:|----------:|
|                PropertyCalling |  2.959 ns | 0.0781 ns | 0.0767 ns |
|          TraditionalReflection | 59.906 ns | 0.9868 ns | 0.8240 ns |
| OptimizedTraditionalReflection | 37.861 ns | 0.6661 ns | 0.6231 ns |
|       CompiledGetterReflection |  6.783 ns | 0.1259 ns | 0.1116 ns |
