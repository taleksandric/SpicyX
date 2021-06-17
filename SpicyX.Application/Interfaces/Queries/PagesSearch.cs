using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.Interfaces.Queries
{
    public class PagesSearch
    {
        public int PerPage { get; set; } = 6;
        public int Page { get; set; } = 1;
    }
}
