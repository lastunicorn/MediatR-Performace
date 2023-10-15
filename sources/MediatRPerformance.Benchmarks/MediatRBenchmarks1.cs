// WebApi Pills
// Copyright (C) 2023 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace DustInTheWind.WebAPiPills.MediatRPerformance.Benchmarks;

[SimpleJob]
public class MediatRBenchmarks1
{
    public string Json;
    private readonly string webApiBaseAddressWith;
    private readonly string webApiBaseAddressWithout;

    public MediatRBenchmarks1()
    {
        Config config = new();
        webApiBaseAddressWith = config.WebApiBaseAddressWith;
        webApiBaseAddressWithout = config.WebApiBaseAddressWithout;
    }

    [Benchmark(Description = "Web API with MediatR - Different HttpClient")]
    public async Task WithMediatR()
    {
        using HttpClient httpClient = new()
        {
            BaseAddress = new Uri(webApiBaseAddressWith)
        };

        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("/WeatherForecast");

        if (!httpResponseMessage.IsSuccessStatusCode)
            throw new Exception("Failed to call the Web API.");

        await using Stream stream = await httpResponseMessage.Content.ReadAsStreamAsync();
        using StreamReader streamReader = new(stream);
        Json = await streamReader.ReadToEndAsync();

        //Json = await httpResponseMessage.Content.ReadAsStringAsync();
    }

    [Benchmark(Description = "Web API with Port - Different HttpClient")]
    public async Task WithPort()
    {
        using HttpClient httpClient = new()
        {
            BaseAddress = new Uri(webApiBaseAddressWithout)
        };

        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("/WeatherForecast");

        if (!httpResponseMessage.IsSuccessStatusCode)
            throw new Exception("Failed to call the Web API.");

        await using Stream stream = await httpResponseMessage.Content.ReadAsStreamAsync();
        using StreamReader streamReader = new(stream);
        Json = await streamReader.ReadToEndAsync();

        //Json = await httpResponseMessage.Content.ReadAsStringAsync();
    }
}
public class AntiVirusFriendlyConfig : ManualConfig
{
    public AntiVirusFriendlyConfig()
    {
        Job job = Job.MediumRun
            .WithToolchain(InProcessNoEmitToolchain.Instance)
            .WithIterationCount(200);

        AddJob(job);
    }
}