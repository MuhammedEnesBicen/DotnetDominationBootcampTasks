using AutoMapper;
using Task5.Models.DTOs;
using Task5.Models.ORM;

namespace Task5.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Client,ClientDTO>().ReverseMap();
            CreateMap<Reservation,ReservationDTO>().ReverseMap();
        }
    }
}
