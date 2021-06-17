using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.Application.Interfaces;
using SpicyX.Application.Interfaces.Commands;
using SpicyX.DataAccess;
using SpicyX.Domain.Entities;
using SpicyX.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Commands
{
    public class ReservationInsert : IReservationInsert
    {
        private readonly SpicyXContext _context;
        private readonly IApplicationUser _actor;
        private readonly ReservationInsertValidation _validator;

        public ReservationInsert(SpicyXContext context, ReservationInsertValidation validator, IApplicationUser actor)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
        }
        public int Id => 17;

        public string Name => "Insert reservation.";

        public void Execute(ReservationDto request)
        {
            _validator.ValidateAndThrow(request);
            var UserId = _actor.Id;
            var reservation = new Reservation()
            {
                UserId=UserId,
                Date=request.Date,
                HowManyPeople=request.HowManyPeople,
                Message=request.Message
            };
            _context.Reservations.Add(reservation);
            _context.SaveChanges();

        }
    }
}
