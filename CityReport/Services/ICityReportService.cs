using CityReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityReport.Services
{
    public interface ICityReportService
    {
        List<string> GetAvailable_Cities();
        Task<TimeZoneModel> GetTimeZoneBy(string city);
        Task<CurrentWeatherModel> GetCurrentWeatherBy(string city);
        Task<AstronomyModel> GetAstronomyBy(string city);
    }
}
