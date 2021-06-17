using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Domain.Entities
{
    public class Meal : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
    }
}
