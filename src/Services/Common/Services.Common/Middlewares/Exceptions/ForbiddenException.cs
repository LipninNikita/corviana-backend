using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Middlewares.Exceptions
{
    public class ForbiddenException : Exception
    {
        public override string Message { get; } = "Forbidden";

        public ForbiddenException(string message)
        {
            Message = message;
        }
        public ForbiddenException()
        {

        }
    }
}
