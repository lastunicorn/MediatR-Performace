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

using DustInTheWind.WebAPiPills.MediatRPerformance.ApplicationWith.PresentWeatherForecast;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.WebAPiPills.MediatRPerformance.WebApiWith.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator mediator;

    public WeatherForecastController(IMediator mediator)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecastViewModel>> Get()
    {
        PresentWeatherForecastRequest request = new();
        PresentWeatherForecastResponse response = await mediator.Send(request);

        return response.Forecasts.Select(x => x.ToViewModel());
    }
}