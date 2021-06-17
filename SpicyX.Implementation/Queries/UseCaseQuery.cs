using AutoMapper;
using SpicyX.Application.DataTransfer;
using SpicyX.Application.Exceptions;
using SpicyX.Application.Interfaces.Queries;
using SpicyX.Application.Search;
using SpicyX.DataAccess;
using SpicyX.Domain.Entities;
using SpicyX.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpicyX.Implementation.Queries
{
    public class UseCaseQuery : IUseCaseQuery
    {
        private readonly SpicyXContext _context;
        private readonly IMapper _mapper;

        public UseCaseQuery(SpicyXContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 16;

        public string Name => "UseCase search";

        public PagesResponse<UseCaseSelectDto> Execute(UseCaseSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.UseCaseName) && !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                search.UseCaseName = search.UseCaseName.ToLower();

                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName));
            }

            if (!string.IsNullOrEmpty(search.Actor) && !string.IsNullOrWhiteSpace(search.Actor))
            {
                search.Actor = search.Actor.ToLower();

                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor));
            }

            if (search.DateFrom.HasValue && search.DateTo.HasValue)
            {
                query = query.Where(x => x.Date >= search.DateFrom && x.Date <= search.DateTo);
            }

            var usecase = query.Paged<UseCaseSelectDto, UseCaseLog>(search, _mapper);

            if (usecase.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(UseCaseLog));
            }
            return usecase;
        }
    }
}
