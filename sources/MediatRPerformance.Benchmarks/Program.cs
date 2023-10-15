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

using System.Diagnostics;
using System.Reflection;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace DustInTheWind.WebAPiPills.MediatRPerformance.Benchmarks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //MediatRBenchmarks1 mediatRBenchmarks = new();

        //Stopwatch stopwatch = Stopwatch.StartNew();
        //await mediatRBenchmarks.WithMediatR();
        //stopwatch.Stop();

        //Console.WriteLine("Call with MediatR:");
        //Console.WriteLine(mediatRBenchmarks.Json);
        //Console.WriteLine("Time: " + stopwatch.Elapsed);


        //stopwatch.Reset();
        //stopwatch.Start();
        //await mediatRBenchmarks.WithPort();
        //stopwatch.Stop();

        //Console.WriteLine("Call without MediatR:");
        //Console.WriteLine(mediatRBenchmarks.Json);
        //Console.WriteLine("Time: " + stopwatch.Elapsed);

        
        BenchmarkRunner.Run(typeof(MediatRBenchmarks1).Assembly);
    }
}