using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpicyX.Implementation.Validations
{
    public class TypeInsertValidation : AbstractValidator<TypeDto>
    {
        public TypeInsertValidation(SpicyXContext _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(n => !_context.Types.Any(m => m.Name == n)).WithMessage("Name is unique");
            });
        }
    }
}
