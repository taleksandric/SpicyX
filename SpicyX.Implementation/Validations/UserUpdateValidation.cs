using FluentValidation;
using SpicyX.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpicyX.Implementation.Validations
{
    public class UserUpdateValidation : UserInsertValidation
    {
        public UserUpdateValidation(SpicyXContext context) : base(context)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").DependentRules(() =>
            {
                RuleFor(x => x.Email).Must((users, email) => !context.Users.Any(y => y.Email == email && y.Id != users.Id))
                .WithMessage("Email already exists.");
            });
        }
    }
}
