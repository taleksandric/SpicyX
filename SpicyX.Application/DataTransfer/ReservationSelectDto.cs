using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.DataTransfer
{
    public class ReservationSelectDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int HowManyPeople { get; set; }
        public string? Message { get; set; }
        public string User { get; set; }
    }
}
