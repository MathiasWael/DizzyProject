using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Exceptions
{
    public class BadRequestException
    {
        public string Message { get; set; }
        public BadRequestException() => Message = string.Empty;
        public BadRequestException(string message) => Message = message;
    }
}
