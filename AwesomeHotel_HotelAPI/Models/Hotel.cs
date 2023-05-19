namespace AwesomeHotel_HotelAPI.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Occupancy { get; set; }
        public int Area { get; set; }
        public DateTime CreatedData { get; set; }
    }
}
