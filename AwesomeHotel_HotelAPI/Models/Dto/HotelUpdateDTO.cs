using System.ComponentModel.DataAnnotations;

namespace AwesomeHotel_HotelAPI.Models.Dto
{
    public class HotelUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Occupancy { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public string Amenities { get; set; }
    }
}
