using AutoMapper;
using Parkable.Infra.Databases.Entities;
using Parkable.Shared.Models;

namespace Parkable.Core.Cars
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>()
                .ForMember(dst => dst.LastUpdateAt, opt => opt.MapFrom(src => src.ModifiedAt ?? src.CreatedAt))
                .ForMember(dst => dst.LastUpdateBy, opt => opt.MapFrom(src => src.ModifiedBy ?? src.CreatedBy));
        }
    }
}
