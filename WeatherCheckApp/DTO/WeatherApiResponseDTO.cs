using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherCheckApp.DTO
{
    public class WeatherApiResponseDTO
    {
        public CurrentWeatherDTO Current { get; set; }
    }

    public class CurrentWeatherDTO
    {
        public List<string> Weather_descriptions { get; set; }
        public int Wind_speed { get; set; }
        public int Uv_index { get; set; }
        public bool IsRaining
        {
            get
            {
                return Weather_descriptions.Any(q => q.Contains("rain"));
            }
        }
    }
}
