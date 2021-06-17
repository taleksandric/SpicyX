
using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.Application.Interfaces;
using SpicyX.Application.Interfaces.Commands;
using SpicyX.DataAccess;
using SpicyX.Domain.Entities;
using SpicyX.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpicyX.Implementation.Commands
{
    public class OrderInsert : IOrderInsert
    {
        private readonly SpicyXContext _context;
        private readonly IApplicationUser _actor;
        private readonly OrderValidation _validator;

        public OrderInsert(SpicyXContext context, OrderValidation validator, IApplicationUser actor )
        {
            _context = context;
            _actor = actor;
            _validator = validator;
        }
        public int Id => 9;

        public string Name => "Insert order";

        public void Execute(OrderDto request)
        {
            _validator.ValidateAndThrow(request);

            var order = new Order
            {
                Date=DateTime.UtcNow,
                UserId = _actor.Id,
                OrderLines = request.OrderLines.Select(x =>
                {
                    

                    var meal = _context.Meals.Find(x.MealId);
                    return new OrderLine
                    {
                        MealId = meal.Id,
                        Price = meal.Price,
                        Quantity = x.Quantity
                    };
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
    
}
