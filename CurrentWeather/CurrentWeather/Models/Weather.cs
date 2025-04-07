
namespace CurrentWeather.Models
{
    public class Weather
    {
        public double? Lon { get; set; }
        public double? Lat { get; set; }
        public double? Temp_Min { get; set; }
        public double? Temp_Max { get; set; }
        public int? Visibility { get; set; }
        public double? Speed { get; set; }
        public string? Main { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public string? Sunrise { get; set; }
        public string? Sunset { get; set; }
        public double? Temp { get; set; }
        public double? Feels_Like { get; set; }
        public int? Pressure { get; set; }
        public int? Humidity { get; set; }
        public int? Sea_Level { get; set; }
        public int? Grnd_Level { get; set; }
    }
}

