using Newtonsoft.Json;
using Test.Models;

namespace Test.Repository
{
    public class Repository:IRepository
    {
        private readonly ILogger _logger;

        public Repository(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("logs");
        }

        public async Task<Response> GetAllHotels()
        {
            Response response =null;
            try
            {
                StreamReader r = new StreamReader("C:\\Users\\kalpe\\source\\repos\\Test\\Test\\JSON\\HotelResponse.json");
                string json = r.ReadToEnd();
                response = JsonConvert.DeserializeObject<Response>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "All function error", typeof(Repository));
            }
            _logger.LogInformation("GetAllHotels - Response :" + response);
            return response;
        }

        public async Task<Response> GetHotelByCity(string city)
        {
            _logger.LogInformation("GetHotelByCity - Request :" + city);
            Response response = null;
            try
            {
                StreamReader r = new StreamReader("C:\\Users\\kalpe\\source\\repos\\Test\\Test\\JSON\\HotelResponse.json");
                string json = r.ReadToEnd();                       
                response = JsonConvert.DeserializeObject<Response>(json);
                response.result.hotelSearchResponse = response.result.hotelSearchResponse.Select(d => d).Where(d => d.address.Contains(city)).ToList();
                _logger.LogInformation("GetHotelByCity - Response :" + response);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "All function error", typeof(Repository));
            }
            return response;
        }
    }
}
