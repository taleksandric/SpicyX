using AutoMapper;
using SpicyX.Application.DataTransfer;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationSelectDto>().ForMember(x => x.User, y => y.MapFrom(t => t.User.FirstName));

            CreateMap<ReservationDto, Reservation>();
        }
    }
}

