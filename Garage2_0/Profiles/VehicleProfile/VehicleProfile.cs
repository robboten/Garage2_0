using AutoMapper;
using Garage2_0.Dtos;
using Garage2_0.Models;

namespace Garage2_0.Profiles.VehicleProfile
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile() 
        {
            CreateMap<Vehicle, VehicleDto>()
               // .ForMember(dest=> dest.Type, opt=>opt.MapFrom(src=>src.VehicleType))
                ;
        }
    }
}
