using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpicyX.Application.DataTransfer;
using SpicyX.Application.Exceptions;
using SpicyX.Application.Interfaces;
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
    public class UserQuery : IUserQuery
    {
        private readonly SpicyXContext _context;
        private readonly IMapper _mapper;

        public UserQuery(SpicyXContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id =>12;

        public string Name => "User search";

        PagesResponse<UserSelectDto> IQuery<UserSearch, PagesResponse<UserSelectDto>>.Execute(UserSearch search)
        {
            var query = _context.Users.Include(x => x.Role).Where(x => x.DeletedAt == null).AsQueryable();
            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);

            }
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                var keyword = search.Keyword.ToLower();
                query = query.Where(x => x.FirstName.ToLower().Contains(keyword) ||
                  x.LastName.ToLower().Contains(keyword) || x.Email.ToLower().Contains(keyword) ||
                  x.Role.Name.ToLower().Contains(keyword)
                );
            }
            var users = query.Paged<UserSelectDto, User>(search, _mapper);
            if (users.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(User));
            }
            return users;
        }
    }
}
