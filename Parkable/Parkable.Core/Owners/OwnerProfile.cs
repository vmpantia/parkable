using AutoMapper;
using Parkable.Core.Owners.Commands;
using Parkable.Infra.Databases.Entities;
using Parkable.Shared.Models.Owners;

namespace Parkable.Core.Owners
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<Owner, OwnerDto>()
                .ForMember(dst => dst.LastUpdateAt, opt => opt.MapFrom(src => src.ModifiedAt ?? src.CreatedAt))
                .ForMember(dst => dst.LastUpdateBy, opt => opt.MapFrom(src => src.ModifiedBy ?? src.CreatedBy));

            CreateMap<CreateOwnerCommand, Owner>();
        }
    }
}
