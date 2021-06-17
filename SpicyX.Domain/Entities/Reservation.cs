using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Domain.Entities
{
    public class Reservation : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public int HowManyPeople { get; set; }
        public string? Message { get; set; }
    }
}
