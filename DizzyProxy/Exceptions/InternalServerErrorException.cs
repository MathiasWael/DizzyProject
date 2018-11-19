using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException() => Message = string.Empty;
        public InternalServerErrorException(string message) => Message = message;
    }
}
