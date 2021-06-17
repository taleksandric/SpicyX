using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.Interfaces
{
    public interface IQuery<TSearch, TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }
}
