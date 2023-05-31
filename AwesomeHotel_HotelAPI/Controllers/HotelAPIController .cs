using AwesomeHotel_HotelAPI.Data;
using AwesomeHotel_HotelAPI.Models;
using AwesomeHotel_HotelAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AwesomeHotel_HotelAPI.Controllers
{
    [Route("api/HotelApi")]
    [ApiController]
    public class HotelAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public HotelAPIController(ApplicationDbContext db) { _db = db;}
        //--------------------------------------------------------------GET ALL--------------------------------------------------------------//
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<HotelDTO>> GetHotels()
        {
            return Ok(_db.Hotels.ToList());
        }
        //--------------------------------------------------------------GET--------------------------------------------------------------//
        [HttpGet("{id:int}",Name ="GetHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HotelDTO> GetHotel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var hotel = _db.Hotels.FirstOrDefault(u => u.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }
        //--------------------------------------------------------------POST--------------------------------------------------------------//
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HotelDTO> CreatHotel([FromBody] HotelDTO hotelDTO) 
        {

            if (_db.Hotels.FirstOrDefault(u=>u.Name.ToLower()==hotelDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("Custom Error", "Hotel is already exist!");
                return BadRequest(ModelState);
            }
            if (hotelDTO == null)
            {
                return BadRequest(hotelDTO);
            }
            if (hotelDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Hotel model = new()
            {
                Id = hotelDTO.Id,
                Name = hotelDTO.Name,
                Occupancy = hotelDTO.Occupancy,
                Area = hotelDTO.Area,
                Rate = hotelDTO.Rate,
                Details = hotelDTO.Details,
                ImageUrl = hotelDTO.ImageUrl,
                Amenities = hotelDTO.Amenities,
            };
            _db.Hotels.Add(model);
            _db.SaveChanges();
            return CreatedAtRoute("GetHotel",new {id = hotelDTO.Id},hotelDTO); 
        }
        //--------------------------------------------------------------DELETE--------------------------------------------------------------//
        [HttpDelete("{id:int}", Name = "DeleteHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteHotel(int id)
        {
            var hotel = _db.Hotels.FirstOrDefault(u=>u.Id==id);
            if (id==0)
            {
                return BadRequest();
            }
            if (hotel==null)
            {
                return NotFound();
            }
            _db.Hotels.Remove(hotel);
            _db.SaveChanges();
            return NoContent();
        }
        //--------------------------------------------------------------UPDATE--------------------------------------------------------------//
        [HttpPut("{id:int}",Name ="UpdateHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public IActionResult UpdateHotel(int id, [FromBody] HotelDTO hotelDTO)
        {
            if (hotelDTO==null || id!= hotelDTO.Id)
            {
                return BadRequest();
            }
            Hotel model = new()
            {
                Id = hotelDTO.Id,
                Name = hotelDTO.Name,
                Occupancy = hotelDTO.Occupancy,
                Area = hotelDTO.Area,
                Rate = hotelDTO.Rate,
                Details = hotelDTO.Details,
                ImageUrl = hotelDTO.ImageUrl,
                Amenities = hotelDTO.Amenities,
            };
            _db.Hotels.Update(model);
            _db.SaveChanges();
            return NoContent();
        }
        //--------------------------------------------------------------PATCH--------------------------------------------------------------//
        [HttpPatch("{id:int}",Name="UpdatePartialHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialHotel(int id,JsonPatchDocument<HotelDTO> patchTO)
        {
            if (patchTO==null || id ==0)
            {
                return BadRequest();
            }
            var hotel = _db.Hotels.AsNoTracking().FirstOrDefault(u=>u.Id==id);

            if (hotel == null)
            {
                return BadRequest();
            }
            HotelDTO hotelDTO = new()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Occupancy = hotel.Occupancy,
                Area = hotel.Area,
                Rate = hotel.Rate,
                Details = hotel.Details,
                ImageUrl = hotel.ImageUrl,
                Amenities = hotel.Amenities,
            };
            patchTO.ApplyTo(hotelDTO,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Hotel model = new()
            {
                Id = hotelDTO.Id,
                Name = hotelDTO.Name,
                Occupancy = hotelDTO.Occupancy,
                Area = hotelDTO.Area,
                Rate = hotelDTO.Rate,
                Details = hotelDTO.Details,
                ImageUrl = hotelDTO.ImageUrl,
                Amenities = hotelDTO.Amenities,
            };
            _db.Hotels.Update(model); 
            _db.SaveChanges();
            return NoContent();
        }
    }
}
