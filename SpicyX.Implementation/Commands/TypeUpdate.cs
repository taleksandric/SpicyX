using AutoMapper;
using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.Application.Exceptions;
using SpicyX.Application.Interfaces.Commands;
using SpicyX.DataAccess;
using SpicyX.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Commands
{
    public class TypeUpdate : IUpdateType
    {
        private readonly SpicyXContext _context;
        private readonly TypeUpdateValidation _validator;
        private readonly IMapper _mapper;

        public TypeUpdate(SpicyXContext context, TypeUpdateValidation validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }
        public int Id => 7;

        public string Name => "Update type.";

        public void Execute(TypeDto request)
        {
            _validator.ValidateAndThrow(request);

            var type = _context.Types.Find(request.Id);
            if (type == null || type.DeletedAt != null)
            {
                throw new EntityNotFoundException(typeof(Type));
            }
            type.Name = request.Name;

            type.DateModified = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
