using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Domain.Entities
{
    public class Order : Entity
    {
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
    }
}
