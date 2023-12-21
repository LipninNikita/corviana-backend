using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Middlewares.Exceptions
{
    public class ContentNotFoundException : Exception
    {
        public override string Message { get; } = "Content not found";

        public ContentNotFoundException(string message) 
        { 
            Message = message;
        }
        public ContentNotFoundException()
        {

        }
    }
}
