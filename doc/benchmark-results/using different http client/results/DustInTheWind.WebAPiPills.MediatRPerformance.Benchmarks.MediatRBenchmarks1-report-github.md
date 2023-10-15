```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2283/22H2/2022Update/SunValley2)
Intel Core i7-8565U CPU 1.80GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2


```
| Method                                        | Mean     | Error     | StdDev    |
|---------------------------------------------- |---------:|----------:|----------:|
| &#39;Web API with MediatR - Different HttpClient&#39; | 4.138 ms | 0.0401 ms | 0.0375 ms |
| &#39;Web API with Port - Different HttpClient&#39;    | 3.888 ms | 0.0752 ms | 0.1126 ms |
