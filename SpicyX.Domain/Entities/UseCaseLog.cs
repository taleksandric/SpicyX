using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Domain.Entities
{
    public class UseCaseLog : Entity
    {
        public DateTime Date { get; set; }
        public string UseCaseName { get; set; }
        public string Data { get; set; }
        public string Actor { get; set; }
    }
}
