using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherCheckApp.DTO;

namespace WeatherCheckApp.Models
{
    public class UserDecision
    {
        private readonly CurrentWeatherDTO _currentWeather;

        public UserDecision(CurrentWeatherDTO currentWeather)
        {
            _currentWeather = currentWeather;
        }

        public bool ShouldGoOutside { get { return !_currentWeather.IsRaining; } }
        public bool ShouldWearSunscreen { get { return _currentWeather.Uv_index > 3; } }
        public bool CanFlyKite { get { return !_currentWeather.IsRaining && _currentWeather.Wind_speed > 15; } }
    }
}
