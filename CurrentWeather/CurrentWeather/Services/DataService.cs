using CurrentWeather.Models;
using Newtonsoft.Json.Linq;
using System.Net;

namespace CurrentWeather.Services
{
    public class DataService
    {
        public static async Task<Weather?>? GetWeather(string city)
        {
            string key = "2ce1ac1548d311ce5b78c0acfc8658f0";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={key}";

            using HttpClient client = new HttpClient();
            HttpResponseMessage response;

            try
            {
                response = await client.GetAsync(url);
            }
            catch (HttpRequestException)
            {
                throw new Exception("No internet connection.");
            }

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var weatherJson = JObject.Parse(json);

                DateTime time = new();
                DateTime timeSunrise = time.AddSeconds((long)weatherJson["sys"]!["sunrise"]!).ToLocalTime();
                DateTime timeSunset = time.AddSeconds((long)weatherJson["sys"]!["sunset"]!).ToLocalTime();

                Weather weather = new()
                {
                    Lon = (double)weatherJson["coord"]!["lon"]!,
                    Lat = (double)weatherJson["coord"]!["lat"]!,
                    Temp_Min = (double)weatherJson["main"]!["temp_min"]!,
                    Temp_Max = (double)weatherJson["main"]!["temp_max"]!,
                    Visibility = (int)weatherJson["visibility"]!,
                    Speed = (double)weatherJson["wind"]!["speed"]!,
                    Main = (string)weatherJson["weather"]![0]!["main"]!,
                    Description = (string)weatherJson["weather"]![0]!["description"]!,
                    Country = (string)weatherJson["sys"]!["country"]!,
                    Sunrise = timeSunrise.ToString("dd/MM/yyyy HH:mm:ss"),
                    Sunset = timeSunset.ToString("dd/MM/yyyy HH:mm:ss"),
                    Temp = (double)weatherJson["main"]!["temp"]!,
                    Feels_Like = (double)weatherJson["main"]!["feels_like"]!,
                    Pressure = (int)weatherJson["main"]!["pressure"]!,
                    Humidity = (int)weatherJson["main"]!["humidity"]!,
                    Sea_Level = (int)weatherJson["main"]!["sea_level"]!,
                    Grnd_Level = (int)weatherJson["main"]!["grnd_level"]!
                };
                return weather;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("City not found.");
            }
            else
            {
                throw new Exception("Failed to retrieve weather data.");
            }
        }
    }
}

// https://api.openweathermap.org/data/2.5/weather?q=jau&units=metric&appid=2ce1ac1548d311ce5b78c0acfc8658f0