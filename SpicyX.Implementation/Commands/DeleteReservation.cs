using SpicyX.Application.Exceptions;
using SpicyX.Application.Interfaces.Commands;
using SpicyX.DataAccess;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Commands
{
    public class DeleteReservation : IDeleteReservation
    {
        private readonly SpicyXContext _context;

        public DeleteReservation(SpicyXContext context)
        {
            _context = context;
        }
        public int Id => 18;

        public string Name => "Delete reservation";

        public void Execute(int request)
        {
            var reservation = _context.Reservations.Find(request);
            if (reservation == null)
            {
                throw new EntityNotFoundException(typeof(Reservation));
            }
            reservation.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
