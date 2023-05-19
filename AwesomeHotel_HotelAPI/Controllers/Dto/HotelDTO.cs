using System.ComponentModel.DataAnnotations;

namespace AwesomeHotel_HotelAPI.Controllers.Dto
{
    public class HotelDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //[MaxLength(30)]
        //[MinLength(3)]
        public int Occupancy { get; set; }
        public int Area { get; set; }
    }
}
