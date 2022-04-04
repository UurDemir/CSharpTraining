# Redis

## Installation Resources 
Redis : https://redis.com/blog/redis-on-windows-10/
Redis Remote Access : https://stackoverflow.com/a/19091231

### Windows WSDL Resources
Windows 10 WSDL Activation : https://docs.microsoft.com/en-us/windows/wsl/setup/environment#set-up-your-linux-username-and-password
Windows Server WSDL Activation : https://docs.microsoft.com/en-us/windows/wsl/install-on-server

### Example Database Resources
AdventureWorks Database : https://docs.microsoft.com/en-us/sql/samples/adventureworks-install-configure?view=sql-server-ver15&tabs=ssms

## Redis vs SQL Benchmark Results

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1586 (21H1/May2021Update)
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


```
|                            Method |        Mean |    Error |   StdDev |
|---------------------------------- |------------:|---------:|---------:|
|                   RedisOneElement |    55.79 ms | 0.422 ms | 0.394 ms |
|    RedisOneElementWithCompression |    48.84 ms | 0.393 ms | 0.328 ms |
|  RedisOneElementWithoutConversion |    48.64 ms | 0.599 ms | 0.560 ms |
|                     SQLOneElement |   123.31 ms | 1.696 ms | 1.586 ms |
|                  RedisAllEachItem |   586.33 ms | 8.586 ms | 8.032 ms |
|   RedisAllEachItemWithCompression |   566.54 ms | 7.622 ms | 7.130 ms |
| RedisAllEachItemWithoutConversion |   593.08 ms | 6.659 ms | 5.561 ms |
|                    SQLAllEachItem | 1,239.36 ms | 8.373 ms | 7.422 ms |
|                          RedisAll |    71.94 ms | 1.040 ms | 0.973 ms |
|           RedisAllWithCompression |    60.32 ms | 0.582 ms | 0.486 ms |
|         RedisAllWithoutConversion |    63.11 ms | 0.911 ms | 0.852 ms |
|                            SQLAll |   144.97 ms | 2.667 ms | 4.307 ms |