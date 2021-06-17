using System;
using FluentValidation;
using System.Collections.Generic;
using System.Text;
using SpicyX.DataAccess;
using System.Linq;

namespace SpicyX.Implementation.Validations
{
    public class MealUpdateValidator : MealValidator
    {
       
        public MealUpdateValidator(SpicyXContext _context) : base(_context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((meal, n) => !_context.Meals.Any(m => m.Name == n && m.Id!=meal.Id)).WithMessage("Meal with this name already exist in database");
            });
        }
    }
}
