# What is the performance penalty when using `MediatR`?

## Production code

I created two web API projects with identical endpoints.

- One is using `MediatR` to call the use cases from the application component.
- The other is using a Primary Port to expose interfaces which are implemented by the application component.

## Benchmark approach

The benchmarks are calling the two APIs and measure the execution time.

I run the benchmark twice with a small difference.

### 1) Using the same `HttpClient` instance

- Instantiate the `HttpClient`, in the constructor of the benchmark, once for each Web API, and reuse it each time to perform the call to the web API.

| Method                                   |     Mean |   Error |  StdDev |
| ---------------------------------------- | -------: | ------: | ------: |
| 'Web API with MediatR - Same HttpClient' | 299.2 us | 1.01 us | 4.09 us |
| 'Web API with Port - Same HttpClient'    | 285.6 us | 0.96 us | 3.95 us |

**Result**: The Web API that uses `MediatR` is slower by 13.6 μs = 0.014 ms

```
1 μs = 0.001 ms = 0.000001 s
```

### 2) Using different `HttpClient` instances

- Instantiate the `HttpClient` each time when a call to the web API is performed and dispose it immediately afterwards.

| Method                                        |     Mean |     Error |    StdDev |
| --------------------------------------------- | -------: | --------: | --------: |
| 'Web API with MediatR - Different HttpClient' | 4.138 ms | 0.0401 ms | 0.0375 ms |
| 'Web API with Port - Different HttpClient'    | 3.888 ms | 0.0752 ms | 0.1126 ms |

**Result**: The Web API that uses `MediatR` is slower by 250 μs = 0.250 ms

```
1 ms = 0.001 s
```

## Note

When instantiating a new `HttpClient` for each call, an exception is throws in some cases.

- See more details in the `socket.error.md` file.

## Donations

> If you like my work and want to support me, you can buy me a coffee:
>
> [![ko-fi](https://www.ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Y8Y62EZ8H)

