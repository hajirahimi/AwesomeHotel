using AwesomeHotel_HotelAPI.Controllers.Dto;

namespace AwesomeHotel_HotelAPI.Data
{
    public static class HotelStore
    {
        public static List<HotelDTO> hotelList = new List<HotelDTO>
            {
                new HotelDTO{Id=1,Name="OceanView",Occupancy=3,Area=30},
                new HotelDTO{Id=2,Name="StreetView",Occupancy=2,Area=25},
                new HotelDTO{Id=3,Name="Penthouse",Occupancy=5,Area=40},
                new HotelDTO{Id=4,Name="Presidential",Occupancy=10,Area=80}
            };
    }
}
