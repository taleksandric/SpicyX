using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpicyX.Implementation.Validations
{
    public class TypeUpdateValidation : AbstractValidator<TypeDto>
    {
        public TypeUpdateValidation(SpicyXContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((type, n) => !_context.Types.Any(m => m.Name == n && m.Id != type.Id)).WithMessage("Type with this name already exist in database");
            });
        }
    }
}
