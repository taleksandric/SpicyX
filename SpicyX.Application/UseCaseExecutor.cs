using SpicyX.Application.Exceptions;
using SpicyX.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpicyX.Application
{
    public class UseCaseExecutor
    {
        private readonly IApplicationUser user;
        private readonly IUseCaseLogger logger;

        public UseCaseExecutor(IApplicationUser user, IUseCaseLogger logger)
        {
            this.user = user;
            this.logger = logger;
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            logger.Log(query, user, search);

            if (!user.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseException(query, user);
            }

            return query.Execute(search);
        }

        public void ExecuteCommand<TRequest>(
            ICommand<TRequest> command,
            TRequest request)
        {
            logger.Log(command, user, request);

            if (!user.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, user);
            }

            command.Execute(request);

        }
    }
}
