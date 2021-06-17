using Newtonsoft.Json;
using SpicyX.Application.Interfaces;
using SpicyX.DataAccess;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Logger
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly SpicyXContext _context;

        public DatabaseUseCaseLogger(SpicyXContext context)
        {
            _context = context;
        }
        public void Log(IUseCase useCase, IApplicationUser user, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = user.Email,
                UseCaseName = useCase.Name,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
            });

            _context.SaveChanges();
        }
    }
}
