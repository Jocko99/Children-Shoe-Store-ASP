using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(int id, Type type) : base($"Entity of type {type.Name} with an id of {id} isn't empty and it can't be deleted.")
        {
        }
        public ConflictException(Type type) : base($"Entity of type {type.Name} can't be activated twice or more.")
        {
        }
    }
}
