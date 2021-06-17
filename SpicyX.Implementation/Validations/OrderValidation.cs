using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.DataAccess;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Validations
{
    public class OrderValidation : AbstractValidator<OrderDto>
    {
        public OrderValidation(SpicyXContext context)
        {
            RuleFor(x => x.OrderLines).NotEmpty().WithMessage("Order lines are required.").DependentRules(() =>
            {
                RuleFor(x => x.OrderLines).Must(ol =>
                    ol.Select(o => o.MealId).Distinct().Count() == ol.Count()
                ).WithMessage("There are duplicate order lines.").DependentRules(() =>
                {
                    RuleForEach(x => x.OrderLines).SetValidator(new OrderLineValidation(context));
                });
            });
        }
    }
}
