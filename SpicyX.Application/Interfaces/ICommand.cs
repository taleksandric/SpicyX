using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.Interfaces
{
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }
}
