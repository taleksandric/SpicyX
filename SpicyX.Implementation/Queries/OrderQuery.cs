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
    public class OrderQuery : IOrderQuery
    {
        private readonly SpicyXContext _context;
        private readonly IMapper _mapper;

        public OrderQuery(SpicyXContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 15;

        public string Name => "Search order.";

        public PagesResponse<OrderSelectDto> Execute(OrderSearch search)
        {
            var query= _context.Orders.Include(x => x.OrderLines).Where(x => x.DeletedAt == null).AsQueryable();
            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);

            }
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                var keyword = search.Keyword.ToLower();
                query = query.Where(x => x.OrderLines.Any(y => y.Meal.Name.ToLower().Contains(keyword.ToLower())));
            }
            if (search.MinPrice.HasValue)
            {
                query = query.Where(x => x.OrderLines.Any(y => y.Meal.Price >= search.MinPrice));
            }
            if (search.MaxPrice.HasValue)
            {
                query = query.Where(x => x.OrderLines.Any(y => y.Meal.Price <= search.MaxPrice));
            }

            var orders = query.Paged<OrderSelectDto, Order>(search, _mapper);
            if (orders.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Order));
            }
            return orders;
        }
    }
}
