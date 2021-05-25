using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherCheckApp.DTO;
using WeatherCheckApp.Services.Interfaces;

namespace WeatherCheckApp.Services
{
    public class WeatherService : IWeatherService
    {
        private const string _weatherApiUrl = "http://api.weatherstack.com"; // free plan does not support https
        private const string _accessKey = "f50b8ae6b302ac20ca1428346e1854bb";
        public async Task<CurrentWeatherDTO> GetCurrentWeather(string zipCode)
        {
            var client = new RestClient(_weatherApiUrl);
            client.UseNewtonsoftJson();

            var request = new RestRequest("current", Method.GET);
            request.AddParameter("access_key", _accessKey);
            request.AddParameter("query", zipCode);

            CurrentWeatherDTO currentWeather;

            try
            {
                var response = await client.ExecuteAsync<WeatherApiResponseDTO>(request);
                if (response.Data.Current == null)
                {
                    // Since the API response is always OK from weatherstack, we deserialize api error content
                    var apiError = JsonConvert.DeserializeObject<ApiResponseErrorDTO>(response.Content);
                    throw new Exception(apiError.Error.Info);
                }

                currentWeather = response.Data.Current;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return currentWeather;
        }
    }
}
