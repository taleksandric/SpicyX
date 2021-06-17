using AutoMapper;
using SpicyX.Application.DataTransfer;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Profiles
{
    class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserSelectDto>();
        }
    }
}
