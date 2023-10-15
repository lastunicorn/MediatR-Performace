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

namespace DustInTheWind.WebAPiPills.MediatRPerformance.Benchmarks;

[SimpleJob(iterationCount: 200)]
public class MediatRBenchmarks2 : IDisposable
{
    public string Json;
    private readonly HttpClient httpClientWith;
    private readonly HttpClient httpClientWithout;

    public MediatRBenchmarks2()
    {
        Config config = new();

        httpClientWith = new HttpClient
        {
            BaseAddress = new Uri(config.WebApiBaseAddressWith)
        };

        httpClientWithout = new HttpClient
        {
            BaseAddress = new Uri(config.WebApiBaseAddressWithout)
        };
    }

    [Benchmark(Description = "Web API with MediatR - Same HttpClient")]
    public async Task WithMediatR()
    {
        HttpResponseMessage httpResponseMessage = await httpClientWith.GetAsync("/WeatherForecast");

        if (!httpResponseMessage.IsSuccessStatusCode)
            throw new Exception("Failed to call the Web API.");

        Json = await httpResponseMessage.Content.ReadAsStringAsync();
    }

    [Benchmark(Description = "Web API with Port - Same HttpClient")]
    public async Task WithPort()
    {
        HttpResponseMessage httpResponseMessage = await httpClientWithout.GetAsync("/WeatherForecast");

        if (!httpResponseMessage.IsSuccessStatusCode)
            throw new Exception("Failed to call the Web API.");

        Json = await httpResponseMessage.Content.ReadAsStringAsync();
    }

    public void Dispose()
    {
        httpClientWith?.Dispose();
        httpClientWithout?.Dispose();
    }
}