using AutoMapper;
using SpicyX.Application.DataTransfer;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Profiles
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<Meal, MealSelectDto>()
                .ForMember(x => x.Type, y => y.MapFrom(t => t.Type.Name));
            CreateMap<MealDto, Meal>();
        }
    }
}
