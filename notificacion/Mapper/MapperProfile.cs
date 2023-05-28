using AutoMapper;
using Microsoft.AspNetCore.Identity;
using notificacion.Configurations.Entities;
using notificacion.Models;

namespace notificacion.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<IdentityUser, RegisterUserDto>().ReverseMap();
            CreateMap<IdentityUser, UserDto>().ReverseMap();
            CreateMap<SetNotification, Notification>().ReverseMap();
        }
    }
}
