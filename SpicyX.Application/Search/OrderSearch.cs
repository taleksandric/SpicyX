using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.Search
{
    public class OrderSearch : Search
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
