using AwesomeHotel_HotelAPI.Controllers.Dto;
using AwesomeHotel_HotelAPI.Data;
using AwesomeHotel_HotelAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace AwesomeHotel_HotelAPI.Controllers
{
    [Route("api/HotelApi")]
    [ApiController]
    public class HotelAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<HotelDTO> GetHotels() 
        {
            return HotelStore.hotelList;
        }
        [HttpGet("{id:int}")]
        public HotelDTO GetHotels(int id)
        {
            return HotelStore.hotelList.FirstOrDefault(u=>u.Id==id);
        }
    }
}
