using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.DataTransfer
{
    public class MealDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int TypeId { get; set; }
    }
}
