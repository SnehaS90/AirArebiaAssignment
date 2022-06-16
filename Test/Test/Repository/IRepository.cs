using Test.Models;

namespace Test.Repository
{
    public interface IRepository
    {
        Task<Response> GetAllHotels();

        Task<Response> GetHotelByCity(string city);
    }
}
