# Strange Socket Error

When instantiating a new `HttpClient` for each call in the benchmark, after a while (sometimes 75 calls, other times 150 calls) an exception is thrown:

- `Only one usage of each socket address (protocol/network address/port) is normally permitted. (localhost:5401)`

I do not understand the reason for this exception. I was careful to dispose the `HttpClient` instance at the end of the benchmark function.

```
System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation.
 ---> System.Net.Http.HttpRequestException: Only one usage of each socket address (protocol/network address/port) is normally permitted. (localhost:5401)
 ---> System.Net.Sockets.SocketException (10048): Only one usage of each socket address (protocol/network address/port) is normally permitted.
   at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.ThrowException(SocketError error, CancellationToken cancellationToken)
   at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.System.Threading.Tasks.Sources.IValueTaskSource.GetResult(Int16 token)
   at System.Net.Sockets.Socket.<ConnectAsync>g__WaitForConnectWithCancellation|277_0(AwaitableSocketAsyncEventArgs saea, ValueTask connectTask, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
   --- End of inner exception stack trace ---
   at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.ConnectAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.CreateHttp11ConnectionAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.AddHttp11ConnectionAsync(HttpRequestMessage request)
   at System.Threading.Tasks.TaskCompletionSourceWithCancellation`1.WaitWithCancellationAsync(CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.GetHttp11ConnectionAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.SendWithVersionDetectionAndRetryAsync(HttpRequestMessage request, Boolean async, Boolean doRequestAuth, CancellationToken cancellationToken)
   at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.<SendAsync>g__Core|83_0(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationTokenSource cts, Boolean disposeCts, CancellationTokenSource pendingRequestsCts, CancellationToken originalCancellationToken)
   at DustInTheWind.WebAPiPills.MediatRPerformance.Benchmarks.MediatRBenchmarks2.WithMediatR() in C:\Projects.pet\WebApi Pills\MediatRPerformace\sources\MediatRPerformance.Benchmarks\MediatRBenchmarks2.cs:line 46
   at BenchmarkDotNet.Autogenerated.Runnable_2.<.ctor>b__3_4() in c:\Projects.pet\WebApi Pills\MediatRPerformace\sources\MediatRPerformance.Benchmarks\bin\Release\net6.0\37b4663d-8409-4817-8002-3d19016b1cde\37b4663d-8409-4817-8002-3d19016b1cde.notcs:line 581
   at BenchmarkDotNet.Autogenerated.Runnable_2.WorkloadActionNoUnroll(Int64 invokeCount) in c:\Projects.pet\WebApi Pills\MediatRPerformace\sources\MediatRPerformance.Benchmarks\bin\Release\net6.0\37b4663d-8409-4817-8002-3d19016b1cde\37b4663d-8409-4817-8002-3d19016b1cde.notcs:line 695
   at BenchmarkDotNet.Engines.Engine.RunIteration(IterationData data)
   at BenchmarkDotNet.Engines.EngineFactory.Jit(Engine engine, Int32 jitIndex, Int32 invokeCount, Int32 unrollFactor)
   at BenchmarkDotNet.Engines.EngineFactory.CreateReadyToRun(EngineParameters engineParameters)
   at BenchmarkDotNet.Autogenerated.Runnable_2.Run(IHost host, String benchmarkName) in c:\Projects.pet\WebApi Pills\MediatRPerformace\sources\MediatRPerformance.Benchmarks\bin\Release\net6.0\37b4663d-8409-4817-8002-3d19016b1cde\37b4663d-8409-4817-8002-3d19016b1cde.notcs:line 560
   --- End of inner exception stack trace ---
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Span`1& arguments, Signature sig, Boolean constructor, Boolean wrapExceptions)
   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at System.Reflection.MethodBase.Invoke(Object obj, Object[] parameters)
   at BenchmarkDotNet.Autogenerated.UniqueProgramName.AfterAssemblyLoadingAttached(String[] args) in c:\Projects.pet\WebApi Pills\MediatRPerformace\sources\MediatRPerformance.Benchmarks\bin\Release\net6.0\37b4663d-8409-4817-8002-3d19016b1cde\37b4663d-8409-4817-8002-3d19016b1cde.notcs:line 57
```

The benchmark tool writes a warning regarding the antivirus:

```
// * Warnings *
Environment
  Summary -> Detected error exit code from one of the benchmarks. It might be caused by following antivirus software:
        - Windows Defender (windowsdefender://)
Use InProcessEmitToolchain or InProcessNoEmitToolchain to avoid new process creation.
```

I tried using the suggested toolchains but the problem persists.