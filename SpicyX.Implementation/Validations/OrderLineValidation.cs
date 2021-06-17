using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpicyX.Implementation.Validations
{
    class OrderLineValidation : AbstractValidator<OrderLineDto>
    {
        public OrderLineValidation(SpicyXContext context)
        {
            RuleFor(x => x.Quantity).Must(x => x > 0).WithMessage("Quantity must be greater than zero.");
            RuleFor(x => x.MealId).Must(x => context.Meals.Any(y => y.Id == x))
                .WithMessage("Product does not exist.");
           
        }
    }
}
