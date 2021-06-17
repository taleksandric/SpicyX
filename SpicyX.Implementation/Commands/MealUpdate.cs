using AutoMapper;
using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.Application.Exceptions;
using SpicyX.Application.Interfaces.Commands;
using SpicyX.DataAccess;
using SpicyX.Domain.Entities;
using SpicyX.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Commands
{
    public class MealUpdate : IMealUpdate
    {
        private readonly SpicyXContext _context;
        private readonly MealUpdateValidator _validator;
        private readonly IMapper _mapper;

        public MealUpdate(SpicyXContext context, MealUpdateValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Update meal.";

        public void Execute(MealDto request)
        {
            _validator.ValidateAndThrow(request);
           
            var meal = _context.Meals.Find(request.Id);
            if (meal == null || meal.DeletedAt != null)
            {
                throw new EntityNotFoundException(typeof(Meal));
            }
            meal.Name = request.Name;
            meal.Description = request.Description;
            meal.Price = request.Price;
            meal.TypeId = request.TypeId;
            meal.DateModified = DateTime.UtcNow;

            _context.SaveChanges();


        }
    }
}
