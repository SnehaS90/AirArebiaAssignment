using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Repository;
using Test.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HotelSearchController : ControllerBase
    {
        private readonly IRepository _repository;
       
        public HotelSearchController(IRepository repository)
        {
            _repository = repository;

        }

        // GET: api/<HotelSearchController>
        [HttpGet]        
        public async Task<Result> Get()
        {
            Response response = await _repository.GetAllHotels();
            return response.result;
        }

        // GET api/<HotelSearchController>/5
        [HttpGet("{city}")]
        public async Task<Result> Get(string city)
        {
            Response response = await _repository.GetHotelByCity(city);
            return response.result;
        }


    }
}
