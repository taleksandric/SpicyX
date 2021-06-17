using AutoMapper;
using SpicyX.Application.DataTransfer;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpicyX.Implementation.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderSelectDto>()
                .ForMember(x => x.User, y => y.MapFrom(t => t.User.FirstName))
                .ForMember(x => x.OrderLines, y => y.MapFrom(order => order.OrderLines.Select(o => new OrderLineSelectDto
                {
                    Price = o.Price,
                    Quantity = o.Quantity,
                    MealId = o.MealId
                }))) ;

        }
    }
}
