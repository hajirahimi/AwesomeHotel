using System.ComponentModel.DataAnnotations;

namespace AwesomeHotel_HotelAPI.Models.Dto
{
    public class HotelCreateDTO
    {
        public string Name { get; set; }
        public int Occupancy { get; set; }
        public int Area { get; set; }
        public int Rate { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public string Amenities { get; set; }
    }
}
