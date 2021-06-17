using AutoMapper;
using FluentValidation;
using SpicyX.Application.DataTransfer;
using SpicyX.Application.Interfaces.Commands;
using SpicyX.DataAccess;
using SpicyX.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Implementation.Commands
{
    public class InsertType : ITypeInsert
    {
        private readonly SpicyXContext _context;
        private readonly TypeInsertValidation _validator;
        private readonly IMapper _mapper;

        public InsertType(SpicyXContext context, TypeInsertValidation validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 6;

        public string Name =>"Insert type" ;

        public void Execute(TypeDto request)
        {
            _validator.ValidateAndThrow(request);
            var type = _mapper.Map<Domain.Entities.Type>(request);

            _context.Types.Add(type);
            _context.SaveChanges();
        }
    }
}
