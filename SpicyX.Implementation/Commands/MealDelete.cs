using SpicyX.Application.Exceptions;
using SpicyX.Application.Interfaces.Commands;
using SpicyX.DataAccess;
using SpicyX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Commands
{
    public class MealDelete : IMealDelete
    {
        private readonly SpicyXContext _context;

        public MealDelete(SpicyXContext context)
        {
            _context = context;
        }

        public int Id => 3;

        public string Name => "Delete meal";

        public void Execute(int request)
        {
            var meal = _context.Meals.Find(request);
            if (meal == null)
            {
                throw new EntityNotFoundException(typeof(Meal));
            }
            meal.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();


        }
    }
}
