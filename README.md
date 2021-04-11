# Redis vs SQL Server

This is a demo app to show the comparison between Redis and SQL Server
in terms of performance. I have used 
[BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) to benchmark
the performance. I have used Redis and SQL Server created in Azure in the 
same region. Created this app and executed in my local machine which connects
both of them.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.14393.4283 (1607/AnniversaryUpdate/Redstone1)
Intel Xeon CPU E5-2660 v3 2.60GHz, 1 CPU, 2 logical and 2 physical cores
Frequency=14318180 Hz, Resolution=69.8413 ns, Timer=HPET
.NET Core SDK=5.0.201
  [Host]     : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  DefaultJob : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT


```
|        Method |     Mean |    Error |   StdDev |
|-------------- |---------:|---------:|---------:|
|    TestDbPerf |  1.736 s | 0.0071 s | 0.0060 s |
| TestRedisPerf | 10.724 s | 0.2113 s | 0.2595 s |

As per the benchmark SQL Server is faster but the point is, speed is not the only 
reason to use Redis cache over SQL Server database but another reason is Redis 
cache reduces good amount of load from the database.

There is a 
[StackOverflow thread](https://stackoverflow.com/questions/62881953/redis-vs-sql-server-performance) 
regarding this one.