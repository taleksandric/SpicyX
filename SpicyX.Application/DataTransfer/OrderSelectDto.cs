using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.DataTransfer
{
    public class OrderSelectDto
    {
        public DateTime Date { get; set; }
        public string User { get; set; }
        public IEnumerable<OrderLineSelectDto> OrderLines { get; set; } = new List<OrderLineSelectDto>();

    }
    public class OrderLineSelectDto {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int MealId { get; set; }
    }
}
