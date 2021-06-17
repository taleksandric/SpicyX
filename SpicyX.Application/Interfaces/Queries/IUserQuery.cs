using SpicyX.Application.DataTransfer;
using SpicyX.Application.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.Interfaces.Queries
{
    public interface IUserQuery : IQuery<UserSearch, PagesResponse<UserSelectDto>>
    {
    }
}
