using SpicyX.DataAccess;
using FluentValidation;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Validations
{
    public class MealInsertValidation : MealValidator
    {
        public MealInsertValidation(SpicyXContext _context) : base(_context)
        {
            
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must( n => !_context.Meals.Any(m => m.Name == n)).WithMessage("Name is unique");
            });
            
        }
    }
}
