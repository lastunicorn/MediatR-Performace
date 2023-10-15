```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2283/22H2/2022Update/SunValley2)
Intel Core i7-8565U CPU 1.80GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  Job-BRLALT : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2

IterationCount=200  

```
| Method                                   | Mean     | Error   | StdDev  |
|----------------------------------------- |---------:|--------:|--------:|
| &#39;Web API with MediatR - Same HttpClient&#39; | 299.2 μs | 1.01 μs | 4.09 μs |
| &#39;Web API with Port - Same HttpClient&#39;    | 285.6 μs | 0.96 μs | 3.95 μs |
