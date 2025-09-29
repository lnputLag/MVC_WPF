using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        private async void GetWeatherBtn_Click(object sender, RoutedEventArgs e)
        {
            string city = UserCityTextBox.Text.Trim();
            if (city.Length < 2)
            {
                MessageBox.Show("Укажите корректный город");
                return;
            }

            try
            {
                string data = await GetWeather(city);
                var json = JObject.Parse(data);
                string temp = json["main"]["temp"].ToString();
                WeatherResults.Text = $"В городе {city} {temp}°C";
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Укажите верный город");
                WeatherResults.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                WeatherResults.Text = "";
            }
        }

        private async Task<string> GetWeather(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_KEY}&units=metric&lang=ru";
                return await client.GetStringAsync(url);
            }
        }
    }
}
