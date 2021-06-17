using SpicyX.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpicyX.Api.Core
{
    public class UnregisteredUser : IApplicationUser
    {
        public int Id => 0;
        public string Email => "Unregistered user";
        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 5, 11 };
    }
}
