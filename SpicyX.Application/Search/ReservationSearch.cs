using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.Search
{
    public class ReservationSearch : Search
    {
        public decimal? MinPeople { get; set; }
        public decimal? MaxPeople { get; set; }
    }
}
