``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2965/21H2/November2021Update)
Intel Core i5-4300M CPU 2.60GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.16 (6.0.1623.17311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.16 (6.0.1623.17311), X64 RyuJIT AVX2


```
|                  Method |     Mean |    Error |   StdDev | Ratio |
|------------------------ |---------:|---------:|---------:|------:|
| StringConcatenationTest | 708.4 ns | 13.78 ns | 15.31 ns |  1.00 |
|       StringBuilderTest | 495.9 ns |  7.41 ns |  6.93 ns |  0.70 |
