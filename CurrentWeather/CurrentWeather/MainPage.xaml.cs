namespace CurrentWeather
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_CityEntry.Text))
                {
                    var weather = await Services.DataService.GetWeather(txt_CityEntry.Text)!;
                    if (weather != null)
                    {
                        string dados_weather = "";

                        dados_weather = $"latitude:  {weather.Lat}\n" +
                                        $"longitude:  {weather.Lon}\n" +
                                        $"temperature:  {weather.Temp}\n" +
                                        $"feels like:  {weather.Feels_Like}\n" +
                                        $"minimum temperature:  {weather.Temp_Min}\n" +
                                        $"maximum temperature:  {weather.Temp_Max}\n" +
                                        $"pressure:  {weather.Pressure}\n" +
                                        $"humidity:  {weather.Humidity}\n" +
                                        $"sea level:  {weather.Sea_Level}\n" +
                                        $"ground level:  {weather.Grnd_Level}\n" +
                                        $"visibility:  {weather.Visibility}\n" +
                                        $"wind speed:  {weather.Speed}\n" +
                                        $"weather:  {weather.Main}\n" +
                                        $"description:  {weather.Description}\n" +
                                        $"country:  {weather.Country}\n" +
                                        $"sunrise:  {weather.Sunrise}\n" +
                                        $"sunset:  {weather.Sunset}\n";

                        lbl_res.Text = dados_weather;
                    }
                    else
                    {
                        lbl_res.Text = "Weather data not found.";
                    }
                }
                else
                {
                    lbl_res.Text = "Please enter a city name.";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
    

}
