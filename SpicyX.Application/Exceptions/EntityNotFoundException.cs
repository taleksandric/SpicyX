using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyX.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type type)
            : base($"Entity of type {type.Name} was not found.")
        {

        }
    }
}
