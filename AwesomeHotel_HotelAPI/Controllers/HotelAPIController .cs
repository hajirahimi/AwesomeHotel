using AutoMapper;
using AwesomeHotel_HotelAPI.Data;
using AwesomeHotel_HotelAPI.Models;
using AwesomeHotel_HotelAPI.Models.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly IMapper _mapper;
        public HotelAPIController(ApplicationDbContext db,IMapper mapper) { _db = db; _mapper = mapper;}

        //--------------------------------------------------------------GET ALL--------------------------------------------------------------//
        [HttpGet][ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
        {
            IEnumerable<Hotel> hotelList = await _db.Hotels.ToListAsync();
            return Ok(_mapper.Map<List<HotelDTO>>(hotelList));
        }
        //--------------------------------------------------------------GET--------------------------------------------------------------//
        [HttpGet("{id:int}",Name ="GetHotel")][ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)][ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var hotel = await _db.Hotels.FirstOrDefaultAsync(u => u.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<HotelDTO>(hotel));
        }
        //--------------------------------------------------------------POST--------------------------------------------------------------//
        [HttpPost][ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)][ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HotelDTO>> CreatHotel([FromBody] HotelCreateDTO createDTO) 
        {
            if (await _db.Hotels.FirstOrDefaultAsync(u=>u.Name.ToLower()== createDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("Custom Error", "Hotel is already exist!");
                return BadRequest(ModelState);
            }
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }
            Hotel model = _mapper.Map<Hotel>(createDTO);
            //Hotel model = new()
            //{
            //    Name = createDTO.Name,
            //    Occupancy = createDTO.Occupancy,
            //    Area = createDTO.Area,
            //    Rate = createDTO.Rate,
            //    Details = createDTO.Details,
            //    ImageUrl = createDTO.ImageUrl,
            //    Amenities = createDTO.Amenities,
            //};
            await _db.Hotels.AddAsync(model);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetHotel",new {id = model.Id},model); 
        }
        //--------------------------------------------------------------DELETE--------------------------------------------------------------//
        [HttpDelete("{id:int}", Name = "DeleteHotel")][ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)][ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _db.Hotels.FirstOrDefaultAsync(u => u.Id == id);
            if (id==0)
            {
                return BadRequest();
            }
            if (hotel==null)
            {
                return NotFound();
            }
            _db.Hotels.Remove(hotel);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        //--------------------------------------------------------------UPDATE--------------------------------------------------------------//
        [HttpPut("{id:int}",Name ="UpdateHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] HotelUpdateDTO updateDTO)
        {
            if (updateDTO == null || id!= updateDTO.Id)
            {
                return BadRequest();
            }
            Hotel model = _mapper.Map<Hotel>(updateDTO);
            //Hotel model = new()
            //{
            //    Id = hotelDTO.Id,
            //    Name = hotelDTO.Name,
            //    Occupancy = hotelDTO.Occupancy,
            //    Area = hotelDTO.Area,
            //    Rate = hotelDTO.Rate,
            //    Details = hotelDTO.Details,
            //    ImageUrl = hotelDTO.ImageUrl,
            //    Amenities = hotelDTO.Amenities,
            //};
            _db.Hotels.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        //--------------------------------------------------------------PATCH--------------------------------------------------------------//
        [HttpPatch("{id:int}",Name="UpdatePartialHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialHotel(int id,JsonPatchDocument<HotelUpdateDTO> patchTO)
        {
            if (patchTO==null || id ==0)
            {
                return BadRequest();
            }
            var hotel = await _db.Hotels.AsNoTracking().FirstOrDefaultAsync(u=>u.Id==id);

            if (hotel == null)
            {
                return BadRequest();
            }
            HotelUpdateDTO hotelDTO = _mapper.Map<HotelUpdateDTO>(hotel);
            //HotelUpdateDTO hotelDTO = new()
            //{
            //    Id = hotel.Id,
            //    Name = hotel.Name,
            //    Occupancy = hotel.Occupancy,
            //    Area = hotel.Area,
            //    Rate = hotel.Rate,
            //    Details = hotel.Details,
            //    ImageUrl = hotel.ImageUrl,
            //    Amenities = hotel.Amenities,
            //};
            patchTO.ApplyTo(hotelDTO,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Hotel model = _mapper.Map<Hotel>(hotelDTO);
            //Hotel model = new()
            //{
            //    Id = hotelDTO.Id,
            //    Name = hotelDTO.Name,
            //    Occupancy = hotelDTO.Occupancy,
            //    Area = hotelDTO.Area,
            //    Rate = hotelDTO.Rate,
            //    Details = hotelDTO.Details,
            //    ImageUrl = hotelDTO.ImageUrl,
            //    Amenities = hotelDTO.Amenities,
            //};
            _db.Hotels.Update(model); 
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
