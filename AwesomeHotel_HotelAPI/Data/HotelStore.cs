using AwesomeHotel_HotelAPI.Controllers.Dto;

namespace AwesomeHotel_HotelAPI.Data
{
    public static class HotelStore
    {
        public static List<HotelDTO> hotelList = new List<HotelDTO>
            {
                new HotelDTO{Id=1,Name="Ocean View"},
                new HotelDTO{Id=2,Name="Street View"}
            };
    }
}
