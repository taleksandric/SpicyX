using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.DataTransfer
{
    public class UserSelectDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
    }
}
