using Newtonsoft.Json;

namespace OfficePrinterAssistant.ApplicationServices.Components.OpenWeather
{
    public class MainData
    {
        [JsonProperty("temp")]
        public float Temp { get; set; }
        [JsonProperty("humidity")]
        public float Humidity { get; set; }
    }
}
