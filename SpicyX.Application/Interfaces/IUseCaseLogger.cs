using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.Interfaces
{
    public interface IUseCaseLogger
    {
        void Log(IUseCase useCase, IApplicationUser user, object useCaseData);
    }
}
