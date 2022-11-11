# Performance

## Benchmark Results
``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2


```
|                     Method |      Mean |    Error |   StdDev |      Gen0 |      Gen1 |     Gen2 | Allocated |
|--------------------------- |----------:|---------:|---------:|----------:|----------:|---------:|----------:|
|             EF6-FirstOrDefault |  12.96 ms | 0.181 ms | 0.170 ms |   78.1250 |   15.6250 |        - |   1.42 MB |
|             EF7-FirstOrDefault |  13.043 ms | 0.0499 ms | 0.0390 ms |   62.5000 |         - |        - |   1342.3 KB |
| EF6-FirstOrDefaultAsNoTracking |  13.61 ms | 0.233 ms | 0.218 ms |   93.7500 |   15.6250 |        - |   1.65 MB |
| EF7-FirstOrDefaultAsNoTracking |  13.433 ms | 0.1545 ms | 0.1370 ms |   62.5000 |         - |        - |  1496.93 KB |
|                       EF6-List |  94.39 ms | 1.772 ms | 1.740 ms | 1833.3333 | 1000.0000 | 333.3333 |  27.81 MB |
|                       EF7-List |  99.009 ms | 1.9601 ms | 2.4789 ms | 2333.3333 | 2166.6667 | 666.6667 | 29100.65 KB |
|           EF6-ListAsNoTracking |  38.92 ms | 0.423 ms | 0.658 ms |  923.0769 |  538.4615 | 153.8462 |   13.5 MB |
|           EF7-ListAsNoTracking |  38.717 ms | 0.7628 ms | 1.6090 ms | 1076.9231 | 1000.0000 | 307.6923 | 13583.98 KB |
|                     EF6-Update |  70.88 ms | 0.294 ms | 0.245 ms | 1500.0000 |  625.0000 | 125.0000 |  22.58 MB |
|                     EF7-Update |   7.708 ms | 0.1527 ms | 0.3509 ms |         - |         - |        - |    84.28 KB |
|                     EF6-Insert |  62.95 ms | 0.175 ms | 0.164 ms |  750.0000 |  250.0000 |        - |  13.92 MB |
|                     EF7-Insert |  51.617 ms | 0.9861 ms | 0.9684 ms |  700.0000 |  200.0000 |        - | 12166.45 KB |
|                 EF6-BulkInsert |  24.32 ms | 0.486 ms | 0.455 ms |  187.5000 |   62.5000 |        - |   3.31 MB |
|                 EF7-BulkInsert |  22.427 ms | 0.2754 ms | 0.2576 ms |  187.5000 |   93.7500 |        - |  3319.28 KB |
|                     EF6-Delete | 280.11 ms | 2.538 ms | 2.120 ms |         - |         - |        - |   4.62 MB |
|                     EF7-Delete | 110.456 ms | 1.3636 ms | 1.0646 ms |  200.0000 |         - |        - |  3400.44 KB |
