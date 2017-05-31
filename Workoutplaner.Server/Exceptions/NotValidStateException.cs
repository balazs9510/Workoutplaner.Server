using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workoutplaner.Server.Exceptions
{
    public class NotValidStateException : Exception
    {
        public NotValidStateException() : base()
        {

        }
        public NotValidStateException(string message) : base(message)
        {
        }

        public NotValidStateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
