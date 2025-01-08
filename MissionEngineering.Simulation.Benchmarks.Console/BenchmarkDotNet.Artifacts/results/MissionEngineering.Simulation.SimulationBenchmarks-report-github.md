```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2605)
AMD Ryzen 5 5560U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


```
| Method      | Mean       | Error    | StdDev   |
|------------ |-----------:|---------:|---------:|
| RunSingle   |   137.9 ms |  2.66 ms |  3.55 ms |
| RunMultiple | 2,179.9 ms | 28.44 ms | 30.43 ms |
