using AwesomeHotel_HotelAPI.Controllers.Dto;
using AwesomeHotel_HotelAPI.Data;
using AwesomeHotel_HotelAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
namespace AwesomeHotel_HotelAPI.Controllers
{
    [Route("api/HotelApi")]
    [ApiController]
    public class HotelAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<HotelDTO>> GetHotels()
        {
            return Ok(HotelStore.hotelList);
        }
        [HttpGet("{id:int}",Name ="GetHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HotelDTO> GetHotels(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var hotel = HotelStore.hotelList.FirstOrDefault(u => u.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HotelDTO> CreatHotel([FromBody] HotelDTO hotelDTO) 
        {
            //if (ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (HotelStore.hotelList.FirstOrDefault(u=>u.Name.ToLower()==hotelDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("Custom Error", "Hotel is already exist!");
                return BadRequest(ModelState);
            }
            if (hotelDTO == null)
            {
                return BadRequest(hotelDTO);
            }
            if (hotelDTO.Id>0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            hotelDTO.Id = HotelStore.hotelList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            HotelStore.hotelList.Add(hotelDTO);
            //return Ok(hotelDTO);
            return CreatedAtRoute("GetHotel",new {id = hotelDTO.Id},hotelDTO); 
        }
       
        [HttpDelete("{id:int}", Name = "DeleteHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteHotel(int id)
        {
            var hotel = HotelStore.hotelList.FirstOrDefault(u=>u.Id==id);
            if (id==0)
            {
                return BadRequest();
            }
            if (hotel==null)
            {
                return NotFound();
            }
            HotelStore.hotelList.Remove(hotel);
            return NoContent();
        }
        
        [HttpPut("{id:int}",Name ="UpdateHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateHotel(int id, [FromBody] HotelDTO hotelDTO)
        {
            if (hotelDTO==null || id!= hotelDTO.Id)
            {
                return BadRequest();
            }
            var hotel = HotelStore.hotelList.FirstOrDefault(u=>u.Id==id);
            hotel.Name = hotelDTO.Name;
            hotel.Area = hotelDTO.Area;
            hotel.Occupancy = hotelDTO.Occupancy;
            return NoContent();
        }
        [HttpPatch("{id:int}",Name="UpdatePartialHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialHotel(int id,JsonPatchDocument<HotelDTO> patchTO)
        {
            if (patchTO==null || id ==0)
            {
                return BadRequest();
            }
            var hotel = HotelStore.hotelList.FirstOrDefault(u=>u.Id==id);
            if (hotel == null)
            {
                return BadRequest();
            }
            patchTO.ApplyTo(hotel,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
