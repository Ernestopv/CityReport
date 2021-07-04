using System.Collections.Generic;

namespace CityReport.Config
{
    /// <summary>
    /// App settings handles URL and Header-Info like API key and API Host
    /// </summary>
    public class AppSettings {

        public List<string> Available_Cities { get; set; }
        public string GetTimeZoneURL { get; set; }
        public string GetCurrentWeatherURL { get; set; }
        public string GetAstronomyURL { get; set; }
        public HeaderInfo HeaderInfo { get; set; }
    
    }
    public class HeaderInfo
    {
        public APIKey APIKey { get; set; }

        public APIHost APIHost { get; set; }
    }

 
    public class APIKey : BaseModel { }
    public class APIHost : BaseModel { }

    public abstract class BaseModel
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
