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
    public class ReservationQuery : IReservationQuery
    {
        private readonly SpicyXContext _context;
        private readonly IMapper _mapper;

        public ReservationQuery(SpicyXContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 19;

        public string Name => "Reservation search.";

        public PagesResponse<ReservationSelectDto> Execute(ReservationSearch search)
        {
            var query = _context.Reservations.Include(x => x.User).Where(x => x.DeletedAt == null).AsQueryable();
            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);
            }
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                var keyword = search.Keyword.ToLower();
                query = query.Where(x => x.Message.ToLower().Contains(keyword) ||
                   x.User.FirstName.ToLower().Contains(keyword) ||
                   x.User.LastName.ToLower().Contains(keyword)
                 );
            }
            if (search.MinPeople.HasValue)
            {
                query = query.Where(x => x.HowManyPeople >= search.MinPeople);
            }
            if (search.MaxPeople.HasValue)
            {
                query = query.Where(x => x.HowManyPeople <= search.MaxPeople);
            }
            var reservations = query.Paged<ReservationSelectDto, Reservation>(search, _mapper);
            if (reservations.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Reservation));
            }
            return reservations;
        }
    }
}
