using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.Interfaces
{
    public interface IApplicationUser
    {
        int Id { get; }
        string Email { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
