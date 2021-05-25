using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherCheckApp.DTO;

namespace WeatherCheckApp.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<CurrentWeatherDTO> GetCurrentWeather(string zipCode);
    }
}
