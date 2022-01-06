using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.Components.OpenWeather
{
    public class WeatherConnector : IWeatherConnector
    {
        private readonly RestClient restClient;
        private readonly string baseUrl = "https://api.openweathermap.org/";
        private readonly string apiKey = "87e2e890155ce895661d338e761ea7d2";

        public WeatherConnector()
        {
            this.restClient = new RestClient(baseUrl);
        }
        public async Task<Weather> Fetch(string city)
        {
            var request = new RestRequest("data/2.5/weather", Method.Get);
            request.AddParameter("appid", this.apiKey);
            request.AddParameter("q", city);
            var queryResult = await restClient.ExecuteAsync(request);
            var weather = JsonConvert.DeserializeObject<Weather>(queryResult.Content);
            return weather;
        }
    }
}
