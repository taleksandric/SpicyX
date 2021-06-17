using SpicyX.Application.Exceptions;
using SpicyX.Application.Interfaces.Commands;
using SpicyX.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Commands
{
    public class DeleteType : ITypeDelete
    {
        private readonly SpicyXContext _context;

        public DeleteType(SpicyXContext context)
        {
            _context = context;
        }
        public int Id => 8;

        public string Name => "Delete type.";

        public void Execute(int request)
        {
            var type = _context.Types.Find(request);
            if (type == null)
            {
                throw new EntityNotFoundException(typeof(Domain.Entities.Type));
            }
            type.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
