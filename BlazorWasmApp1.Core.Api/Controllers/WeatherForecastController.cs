using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using BlazorWasmApp1.Shared.Controllers;
using BlazorWasmApp1.Shared.Extensions;

using BlazorWasmApp1.Shared.Models;
using BlazorWasmApp1.Shared.Models.Common.ApiResult;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace BlazorWasmApp1.Core.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    //public class WeatherForecastController : ControllerBase
    public class WeatherForecastController : BaseApiController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        // https://localhost:44390/weatherforecast
        [HttpGet]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "<Pending>")]
        //public IEnumerable<WeatherForecast> Get()
        public ActionResult<IApiResultModel<IEnumerable<WeatherForecast>>> Get()
        {
            var rng = new Random();
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
            //.ToArray()
            var apiResult = CreateApiResultModel<IEnumerable<WeatherForecast>>()
                .SetData(data)
                .AddMessage(ApiResultMessageTypeEnum.Information, "Some info", nameof(Get), HttpStatusCode.OK)
                .AddMessage(new Exception("Testing"));


            var json = apiResult.Serialize();

            var apiResult2 = json.Deserialize<ApiResultModel<IEnumerable<WeatherForecast>>>();

            return CreateActionResult(apiResult, false);
        }
    }
}
