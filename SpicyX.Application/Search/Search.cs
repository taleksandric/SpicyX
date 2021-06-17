using SpicyX.Application.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.Search
{
    public class Search : PagesSearch
    {
        public int? Id { get; set; }
        public string Keyword { get; set; }
    }
}
