using AutoMapper;
using AwesomeHotel_HotelAPI.Models;
using AwesomeHotel_HotelAPI.Models.Dto;

namespace AwesomeHotel_HotelAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Hotel, HotelDTO>();
            CreateMap<HotelDTO, Hotel>();
            CreateMap<Hotel, HotelCreateDTO>().ReverseMap();
            CreateMap<Hotel, HotelUpdateDTO>().ReverseMap();
        }
    }
}
