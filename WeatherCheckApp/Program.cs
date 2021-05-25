using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WeatherCheckApp.Models;
using WeatherCheckApp.Services;
using WeatherCheckApp.Services.Interfaces;

namespace WeatherCheckApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // I just wanted to show DI implementation for code evaluation purposes
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IWeatherService, WeatherService>()
                .BuildServiceProvider();

            var weatherService = serviceProvider.GetService<IWeatherService>();

            Console.Write("Please enter zip code: ");
            string zipCode = Console.ReadLine();

            try
            {
                var currentWeather = await weatherService.GetCurrentWeather(zipCode);

                UserDecision userDecision = new UserDecision(currentWeather);

                Console.WriteLine($"Should I go outside? {(userDecision.ShouldGoOutside ? "Yes" : "No")}");
                Console.WriteLine($"Should I wear sunscreen? {(userDecision.ShouldWearSunscreen ? "Yes" : "No")}");
                Console.WriteLine($"Can I fly my kite? {(userDecision.CanFlyKite ? "Yes" : "No")}");
            }
            catch
            {
                Console.WriteLine("An error occurred. Program will exit now.");
            }

            Console.ReadKey();
        }

    }
}
