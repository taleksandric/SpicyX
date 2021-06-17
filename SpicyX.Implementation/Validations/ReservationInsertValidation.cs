using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Validations
{
    public class ReservationInsertValidation : AbstractValidator<ReservationDto>
    {
        public ReservationInsertValidation(SpicyXContext _context) 
        {
            /*var date = DateTime.UtcNow;

            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required")
                .DependentRules(() =>
            {
                RuleFor(x => x.Date).Must(n => n > date).WithMessage("Date must be for today or the future.");
            });*/
            RuleFor(x => x.HowManyPeople).NotEmpty().WithMessage("How many people is required").DependentRules(() =>
            {
                RuleFor(x => x.HowManyPeople).Must(n => n > 1).WithMessage("Reservation must be for one human or more.");
            });

        }
    }
}
