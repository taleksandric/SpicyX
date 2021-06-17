using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Domain.Entities
{
    public class Type : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Meal> Meals { get; set; } = new HashSet<Meal>();
    }
}
