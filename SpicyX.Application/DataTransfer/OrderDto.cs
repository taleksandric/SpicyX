using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.DataTransfer
{
    public class OrderDto
    {
        public IEnumerable<OrderLineDto> OrderLines { get; set; } = new List<OrderLineDto>();
    }

    public class OrderLineDto
    {
        public int MealId { get; set; }
        public int Quantity { get; set; }
    }
}
