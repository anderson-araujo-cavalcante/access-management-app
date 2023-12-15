using AleffGroup.Domain.Entities;
using AleffGroup.WebMvc.ViewModels;
using AutoMapper;

namespace AleffGroup.WebMvc.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}