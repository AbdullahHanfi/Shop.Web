using AutoMapper;
using Shop.Core.Models;
using Shop.Core.ViewModel;

namespace Shop.Core.MappingProfile
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
                .ReverseMap();
            CreateMap<User, AccountDataViewModel>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.ProfilePicture, src => src.MapFrom(src => src.ProfilePicture ))
                .ReverseMap();
            CreateMap<User, AccountDataViewModel>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.ProfilePicture, src => src.MapFrom(src => src.ProfilePicture ))
                .ReverseMap();

        }
    }
}
