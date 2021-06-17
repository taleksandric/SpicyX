using SpicyX.Application.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.Search
{
    public class UseCaseSearch : PagesSearch
    {
        public string UseCaseName { get; set; }
        public string Actor { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
