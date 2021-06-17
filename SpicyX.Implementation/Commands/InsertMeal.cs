using AutoMapper;
using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.Application.Interfaces.Commands;
using SpicyX.DataAccess;
using SpicyX.Domain.Entities;
using SpicyX.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Commands
{
    public class InsertMeal : IMealInsert
    {
        private readonly SpicyXContext _context;
        private readonly MealInsertValidation _validator;
        private readonly IMapper _mapper;

        public InsertMeal(SpicyXContext context, MealInsertValidation validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Insert meal";

        public void Execute(MealDto request)
        {
            _validator.ValidateAndThrow(request);
            var meal = _mapper.Map<Meal>(request);

            _context.Meals.Add(meal);
            _context.SaveChanges();
        }
    }
}
