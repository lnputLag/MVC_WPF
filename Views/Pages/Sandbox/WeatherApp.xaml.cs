using System;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace MVC_WPF.Views.Pages.Sandbox
{
    /// <summary>
    /// Логика взаимодействия для WeatherApp.xaml
    /// </summary>
    public partial class WeatherApp : Page
    {
        private const string API_KEY = "3d9de74844d28377e81415151cbe6a66";

        public WeatherApp()
        {
            InitializeComponent();
        }

        private async void GetWeatherBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string city = UserCityTextBox.Text.Trim();
            if(city.Length < 2)
            {
                MessageBox.Show("Укажите корректный город");
                return;
            }

            try
            {
                string data = await GetWeather(city);
                var json = JObject.Parse(data);
                string temp = json["main"]["temp"].ToString();
                WeatherResults.Text = $"В городе {city} {temp} градусов";
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Укажите верный город");
                WeatherResults.Text = "";
            }
        }

        private async Task<string> GetWeather(string city)
        {
            HttpClient client = new HttpClient();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_KEY}&units=metric";
            return await client.GetStringAsync(url);
        }
    }
}
