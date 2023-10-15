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

using System.Collections;

namespace DustInTheWind.WebAPiPills.MediatRPerformance.Domain;

public class IntervalForecast : IEnumerable<WeatherForecast>
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly WeatherForecast[] forecasts;

    public IntervalForecast()
    {
        forecasts = Enumerable.Range(1, 5)
            .Select(GenerateForDay)
            .ToArray();
    }

    private static WeatherForecast GenerateForDay(int dayIndex)
    {
        return new WeatherForecast
        {
            Date = DateTime.Now.AddDays(dayIndex),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
    }

    public IEnumerator<WeatherForecast> GetEnumerator()
    {
        return ((IEnumerable<WeatherForecast>)forecasts).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}