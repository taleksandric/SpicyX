using AutoMapper;
using SpicyX.Application.DataTransfer;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Profiles
{
    public class UseCaseProfile : Profile
    {
        public UseCaseProfile()
        {
            CreateMap<UseCaseLog, UseCaseSelectDto>();
        }
    }
}
