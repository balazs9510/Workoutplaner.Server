using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workoutplaner.Server.Exceptions
{
    public class EntityCannotDeleteException : Exception
    {
        public EntityCannotDeleteException() : base()
        {

        }
        public EntityCannotDeleteException(string message) : base(message)
        {
        }

        public EntityCannotDeleteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
