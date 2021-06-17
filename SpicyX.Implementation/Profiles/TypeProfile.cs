using AutoMapper;
using SpicyX.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Profiles
{
    public class TypeProfile : Profile
    {
        public TypeProfile()
        {
            CreateMap<Domain.Entities.Type, TypeSelectDto>();
                              
            CreateMap<TypeDto, Domain.Entities.Type>();
        }
    }
}
