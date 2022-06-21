using AutoMapper;
using RentalCarWebApi.Dtos;
using RentalCarWebApi.Models;
using RentalCarWebApi.Models;

namespace RentalCarWebApi.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CarCreateDto,Car>();
            CreateMap<Car, CarGetDto>();


            CreateMap<MemberCreateDto, Member>();
            CreateMap<Member, MemberGetDto>();
        }
    }
}
