using SpicyX.Application.Exceptions;
using SpicyX.Application.Interfaces.Commands;
using SpicyX.DataAccess;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Commands
{
    public class DeleteOrder : IOrderDelete
    {
        private readonly SpicyXContext _context;

        public DeleteOrder(SpicyXContext context)
        {
            _context = context;
        }
        public int Id => 10;

        public string Name => "Delete order";

        public void Execute(int request)
        {
            var order = _context.Orders.Find(request);
            if (order == null)
            {
                throw new EntityNotFoundException(typeof(Order));
            }
            order.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
