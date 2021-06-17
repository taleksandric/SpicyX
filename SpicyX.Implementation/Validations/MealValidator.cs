using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.DataAccess;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Validations
{
    public class MealValidator : AbstractValidator<MealDto>
    {
        public MealValidator(SpicyXContext _context)
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required.");
            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Price is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Price).GreaterThan(0)
                    .WithMessage("Price must be greater then 0.");
                });
            RuleFor(x => x.TypeId).NotEmpty()
                .WithMessage("Type is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.TypeId)
                    .Must(x => _context.Types.Any(t => t.Id == x))
                    .WithMessage("Type doesn't exists in database");
                });
        }
    }
}
