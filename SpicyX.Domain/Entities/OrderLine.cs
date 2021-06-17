using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Domain.Entities
{
    public class OrderLine : Entity
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int MealId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
