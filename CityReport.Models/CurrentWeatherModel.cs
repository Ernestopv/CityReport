namespace CityReport.Models
{
    public class CurrentWeatherModel
    {
        public Current Current { get; set; }
    }

    public class Current
    {
        public string Temp_c { get; set; }
        public Condition Condition { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }

        public string Icon { get; set; }
    }
}
