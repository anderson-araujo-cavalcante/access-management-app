using AleffGroup.Domain.Entities;
using AleffGroup.WebMvc.ViewModels;
using AutoMapper;

namespace AleffGroup.WebMvc.AutoMapper.Profiles
{
    public class LogAccessProfile : Profile
    {
        public LogAccessProfile()
        {
            CreateMap<LogAccess, LogAccessViewModel>()
                .ForMember(destination => destination.UserName, source => source.MapFrom(item => item.User.Name))
                .ReverseMap();
        }
    }
}