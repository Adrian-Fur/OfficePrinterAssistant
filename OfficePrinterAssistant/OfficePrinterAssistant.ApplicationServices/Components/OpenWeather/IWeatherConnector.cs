using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.Components.OpenWeather
{
    public interface IWeatherConnector
    {
        Task<Weather> Fetch(string city);
    }
}
