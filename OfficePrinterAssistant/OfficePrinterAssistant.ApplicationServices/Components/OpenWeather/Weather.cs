using Newtonsoft.Json;

namespace OfficePrinterAssistant.ApplicationServices.Components.OpenWeather
{
    public class Weather
    {
        public string CityName { get; set; }

        [JsonProperty("main")]
        public MainData Main { get; set; }  
    }
}
