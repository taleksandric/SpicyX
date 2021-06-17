using SpicyX.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationUser user)
            : base($"User {user.Email} with an id {user.Id} tried to execute {useCase.Name}.")
        {

        }
    }
}
