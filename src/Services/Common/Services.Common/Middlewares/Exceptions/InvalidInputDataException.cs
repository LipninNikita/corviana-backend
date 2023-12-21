using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Middlewares.Exceptions
{
    public class InvalidInputDataException : Exception
    {
        public override string Message { get; } = "Some fields are invalid!";

        public InvalidInputDataException(string message)
        {
            Message = message;
        }

        public InvalidInputDataException()
        {
        }
    }
}
