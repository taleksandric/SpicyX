using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.Application.Email;
using SpicyX.Application.Interfaces.Commands;
using SpicyX.DataAccess;
using SpicyX.Domain.Entities;
using SpicyX.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpicyX.Implementation.Commands
{
    public class UserInsert : IUserInsert
    {
        private readonly SpicyXContext _context;
        private readonly UserInsertValidation _validator;
        private readonly IEmailSender _sender;

        public UserInsert(SpicyXContext context, UserInsertValidation validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }

        public int Id =>11;

        public string Name => "Registration";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);
            var roleId = _context.Roles.FirstOrDefault(x => x.Name == "User");

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                Address = request.Address,
                RoleId = roleId.Id
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                Content = "You have successfully registered!",
                SendTo = request.Email,
                Subject = "Registration"
            });
        }
    }
}
