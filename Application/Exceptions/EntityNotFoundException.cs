using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, Type type)
            : base($"Entity of type {type.Name} with an id of {id} was not found.")
        {

        }
        public EntityNotFoundException(int first,int second,Type firstType, Type secondType)
            : base($"Entity of type {firstType.Name} with an id of {first} and entity of type {secondType.Name} with an id of {second} was not found.")
        {

        }
    }
}
