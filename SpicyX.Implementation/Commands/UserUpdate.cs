using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.Application.Exceptions;
using SpicyX.Application.Interfaces.Commands;
using SpicyX.DataAccess;
using SpicyX.Domain.Entities;
using SpicyX.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Commands
{
    public class UserUpdate : IUserUpdate
    {
        private readonly SpicyXContext _context;
        private readonly UserUpdateValidation _validator;

        public UserUpdate(SpicyXContext context, UserUpdateValidation validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 13;

        public string Name => "Update user.";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);
            var user = _context.Users.Find(request.Id);

            if (user == null || user.DeletedAt != null)
            {
                throw new EntityNotFoundException(typeof(User));
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Password = request.Password;
            user.Address = request.Address;
            user.DateModified = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
