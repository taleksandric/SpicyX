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
    public class MealQuery : IMealQuery
    {
        private readonly SpicyXContext _context;
        private readonly IMapper _mapper;

        public MealQuery(SpicyXContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 1;

        public string Name => "Meal search";

        public PagesResponse<MealSelectDto> Execute(MealSearch search)
        {
            var query=_context.Meals.Include(x=>x.Type).Where(x=>x.DeletedAt==null).AsQueryable();
            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);
                
            }
            
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                var keyword = search.Keyword.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(keyword) ||
                  x.Description.ToLower().Contains(keyword) ||
                  x.Type.Name.ToLower().Contains(keyword)
                );
            }
            if (search.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price >= search.MinPrice);
            }
            if (search.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= search.MaxPrice);
            }
            var meals= query.Paged<MealSelectDto, Meal>(search, _mapper);
            if (meals.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Meal));
            }
            return meals;
        }
    }
}
