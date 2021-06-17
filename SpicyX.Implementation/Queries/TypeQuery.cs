using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class TypeQuery : ITypeQuery
    {
        private readonly SpicyXContext _context;
        private readonly IMapper _mapper;

        public TypeQuery(SpicyXContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 5;

        public string Name =>"Search type.";

        public PagesResponse<TypeSelectDto> Execute(TypeSearch search)
        {
            var query = _context.Types.Where(x => x.DeletedAt == null).AsQueryable();
            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);
                
            }
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                var keyword = search.Keyword.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(keyword)
                );
            }

            var types = query.Paged<TypeSelectDto, Domain.Entities.Type>(search, _mapper);
            if (types.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Domain.Entities.Type));
            }
            return types;
        }
            
            
    }
}
