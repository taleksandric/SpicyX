using SpicyX.Application.Exceptions;
using SpicyX.Application.Interfaces.Commands;
using SpicyX.DataAccess;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Commands
{
    public class UserDelete : IUserDelete
    {
        private readonly SpicyXContext _context;

        public UserDelete(SpicyXContext context)
        {
            _context = context;
        }
        public int Id => 14;

        public string Name => "Delete user";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);
            if (user == null)
            {
                throw new EntityNotFoundException(typeof(User));
            }
            user.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
