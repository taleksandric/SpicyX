using SpicyX.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpicyX.Api.Core
{
    public class JwtUser : IApplicationUser
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
