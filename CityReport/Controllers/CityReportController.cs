using CityReport.Models;
using CityReport.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CityReport.Controllers
{
    /// <summary>
    /// This controller handles Timezone,CurrentWeather and Astronomy data from external API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CityReportController : ControllerBase
    {
        private readonly ICityReportService _service;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityReportService"></param>
        public CityReportController(ICityReportService cityReportService)
        {
            _service = cityReportService;
        }

        /// <summary>
        /// Available Cities from Solution
        /// </summary>
        /// <returns> List of cities </returns>
        /// <response code="200">Available Cities </response>
        [HttpGet("GetAvailableCities")]
        [ProducesResponseType(typeof(List<string>), 200)]
        public IActionResult GetAvailableCities()
        {
            return Ok(_service.GetAvailable_Cities());
        }

        /// <summary>
        /// TimeZone by city 
        /// </summary>
        /// <remarks>Get the region,country,latitude and localTime from city</remarks>
        /// <param name="city">Select city</param>
        /// <returns>TimeZone  </returns>
        /// <response code="200">Get TimeZone </response>
        /// <response code="400">Bad Request (wrong input as a city)</response>
        [HttpGet("GetTimeZoneBy")]
        [ProducesResponseType(typeof(TimeZoneModel), 200)]
        public async Task<IActionResult> GetTimeZoneBy([Required] string city)
        {
            var result = await _service.GetTimeZoneBy(city);
            return result == null ? BadRequest() : Ok(result);
        }


        /// <summary>
        /// Current Weather by city
        /// </summary>
        /// <remarks>Get the temperature in celsius and the weather condition with text and Icon </remarks>
        /// <param name="city">Select city</param>
        /// <returns>Current Weather</returns>
        /// <response code="200">Get Current Weather </response>
        /// <response code="400">Bad Request (wrong input as a city)</response>
        [HttpGet("GetCurrentWeatherBy")]
        [ProducesResponseType(typeof(CurrentWeatherModel), 200)]
        public async Task<IActionResult> GetCurrentWeatherBy([Required] string city)
        {
            var result = await _service.GetCurrentWeatherBy(city);
            return result == null ? BadRequest() : Ok(result);
           
        }

        /// <summary>
        /// Astronomy by city
        /// </summary>
        ///<remarks> Get the Sunrise, Sunset time and the Moon phase</remarks>
        /// <param name="city">Select city</param>
        /// <returns>Astronomy</returns>
        /// <response code="200">Get Astronomy </response>
        /// <response code="400">Bad Request (wrong input as a city)</response>
        [HttpGet("GetAstronomyBy")]
        [ProducesResponseType(typeof(AstronomyModel), 200)]
        public async Task<IActionResult> GetAstronomyBy([Required] string city)
        {
            var result = await _service.GetAstronomyBy(city);
            return result == null ? BadRequest() : Ok(result);
        }
    }
}
