using CityReport.Config;
using CityReport.Controllers;
using CityReport.Models;
using CityReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CityReport.Tests
{
    public class CityReportUnitTest
    {
       private  IConfigurationRoot _config;
        private IOptions<AppSettings> _appSettings;
        private ICityReportService _service;
        private CityReportController _controller;
        public CityReportUnitTest()
        {
            _config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();
            _appSettings = Options.Create(_config.GetSection("AppSettings").Get<AppSettings>());
            _service = new CityReportService(_appSettings,new System.Net.Http.HttpClient());
            _controller = new CityReportController(_service);
        }
      
        [Fact]
        public void TestAPIExternalKey_And_HostFrom_AppSettings()
        {      
            Assert.Equal("de8b9d1a77mshfd3d503eb2b9642p1b6db5jsncca6c9e91f20", _appSettings.Value.HeaderInfo.APIKey.Value);
            Assert.Equal("x-rapidapi-key", _appSettings.Value.HeaderInfo.APIKey.Key);
            Assert.Equal("weatherapi-com.p.rapidapi.com", _appSettings.Value.HeaderInfo.APIHost.Value);
            Assert.Equal("x-rapidapi-host", _appSettings.Value.HeaderInfo.APIHost.Key);
        }

       
        // Testing Service
        [Fact]
        public void Test_GetAvailable_Cities()
        {
            var availableCities = new List<string> { "Beijing", "Nairobi", "New York", "Mumbai", "Paris", "Sydney" };
            var result = _service.GetAvailable_Cities();
            Assert.True(availableCities.SequenceEqual(result));
        }

        [Fact]
        public async void Test_GetTimeZoneBy_No_City_Name()
        {
            var result = await _service.GetTimeZoneBy("Roldjdd");
            Assert.Null(result);
        }

        [Fact]
        public async void Test_GetTimeZoneBy_using_Null()
        {
            var result = await _service.GetTimeZoneBy(null);
            Assert.Null(result);
        }

        [Fact]
        public async void Test_GetTimeZoneBy_using_proper_city()
        {
            var result = await _service.GetTimeZoneBy("Beijing");
            Assert.IsType<TimeZoneModel>(result);
        }

        [Fact]
        public async void Test_GetCurrentWeatherBy_No_City_Name()
        {
            var result = await _service.GetCurrentWeatherBy("Roldjdd");
            Assert.Null(result);
        }

        [Fact]
        public async void Test_GetCurrentWeatherBy_using_Null()
        {
            var result = await _service.GetCurrentWeatherBy(null);
            Assert.Null(result);
        }

        [Fact]
        public async void Test_GetCurrentWeatherBy_using_proper_city()
        {
            var result = await _service.GetCurrentWeatherBy("Beijing");
            Assert.IsType<CurrentWeatherModel>(result);
        }


        [Fact]
        public async void Test_GetAstronomyBy_No_City_Name()
        {
            var result = await _service.GetAstronomyBy("Roldjdd");
            Assert.Null(result);
        }

        [Fact]
        public async void Test_GetAstronomyBy_using_Null()
        {
            var result = await _service.GetAstronomyBy(null);
            Assert.Null(result);
        }

        [Fact]
        public async void Test_GetAstronomyBy_using_proper_city()
        {
            var result = await _service.GetAstronomyBy("Beijing");
            Assert.IsType<AstronomyModel>(result);
        }

        // Testing Controller
        [Fact]
        public async void Testing_Endpoints_withNullValues()
        {
            var timeZoneResult = await _controller.GetTimeZoneBy(null);
            var cuWeatherResult = await _controller.GetCurrentWeatherBy(null);
            var astronomyResult = await _controller.GetAstronomyBy(null);
           
            Assert.IsNotType<TimeZoneModel>(timeZoneResult);
            Assert.IsNotType<CurrentWeatherModel>(cuWeatherResult);
            Assert.IsNotType<AstronomyModel>(astronomyResult);
        }

        [Fact]
        public async void TestController_GetTimeZoneBy()
        {
            var timeZoneResult = await _controller.GetTimeZoneBy("Paris");
           var okResult= Assert.IsType<OkObjectResult>(timeZoneResult);
            Assert.IsType<TimeZoneModel>(okResult.Value);
        
        }

        [Fact]
        public async void TestController_GetCurrentWeatherBy()
        {
            var cuWeatherResult = await _controller.GetCurrentWeatherBy("Paris");
            var okResult = Assert.IsType<OkObjectResult>(cuWeatherResult);
            Assert.IsType<CurrentWeatherModel>(okResult.Value);

        }

        [Fact]
        public async void TestController_GetAstronomyBy()
        {
            var astronomyResult = await _controller.GetAstronomyBy("Paris");
            var okResult = Assert.IsType<OkObjectResult>(astronomyResult);
            Assert.IsType<AstronomyModel>(okResult.Value);

        }

    }
}
