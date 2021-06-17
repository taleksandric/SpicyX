﻿using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpicyX.Implementation.Validations
{
    public class UserInsertValidation : AbstractValidator<UserDto>
    {
        public UserInsertValidation(SpicyXContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.").DependentRules(() =>
            {
                RuleFor(x => x.FirstName).MinimumLength(3).MaximumLength(35).Matches("^[A-Z][a-z]")
                .WithMessage("First name is not entered correctly.");
            });

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.").DependentRules(() =>
            {
                RuleFor(x => x.FirstName).MinimumLength(3).MaximumLength(45).Matches("^[A-Z][a-z]")
                .WithMessage("Last name is not entered correctly.");
            });

            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.").DependentRules(() =>
            {
                RuleFor(x => x.Password).MinimumLength(4).Matches("[a-z]").Matches("[0-9]")
                .WithMessage("Password is not entered correctly.");
            });

           
        }
    }
}
