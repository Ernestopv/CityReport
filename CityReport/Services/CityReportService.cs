using CityReport.Config;
using CityReport.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CityReport.Services
{
    /// <summary>
    /// This Service handles Timezone,CurrentWeather and Astronomy data from external API
    /// </summary>
    public class CityReportService : ICityReportService
    {
        protected readonly AppSettings _appSettings;
        private  HttpClient _Client { get; }
        public CityReportService(IOptions<AppSettings> appSettings, HttpClient client)
        {
            _appSettings = appSettings.Value;
            client.BaseAddress = new Uri("https://weatherapi-com.p.rapidapi.com/");
            client.DefaultRequestHeaders.Add(_appSettings.HeaderInfo.APIHost.Key, _appSettings.HeaderInfo.APIHost.Value);
            client.DefaultRequestHeaders.Add(_appSettings.HeaderInfo.APIKey.Key, _appSettings.HeaderInfo.APIKey.Value);
            _Client = client;
                  
        }
        public async Task<AstronomyModel> GetAstronomyBy(string city)
        {
            var response = await _Client.GetAsync(_appSettings.GetAstronomyURL + city);
            if (!response.IsSuccessStatusCode) return null;
                var content = await response.Content.ReadAsStringAsync();
                var astronomyFromCity = JsonConvert.DeserializeObject<AstronomyModel>(content);
                return astronomyFromCity;
            
        }

        public async Task<CurrentWeatherModel> GetCurrentWeatherBy(string city)
        {
                var response = await _Client.GetAsync(_appSettings.GetCurrentWeatherURL + city);
                var content = await response.Content.ReadAsStringAsync();
               if (!response.IsSuccessStatusCode) return null;
                var cuWeatherFromCity = JsonConvert.DeserializeObject<CurrentWeatherModel>(content);
                return cuWeatherFromCity;  
        }

        public async Task<TimeZoneModel> GetTimeZoneBy(string city)
        {
            var response = await _Client.GetAsync(_appSettings.GetTimeZoneURL + city);
            var content  =await  response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return null;
            var TimeZoneFromCity = JsonConvert.DeserializeObject<TimeZoneModel>(content);
            return TimeZoneFromCity;
        }

        public List<string> GetAvailable_Cities()
        {
            return _appSettings.Available_Cities;
        }
    }
}
