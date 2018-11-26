using System;

namespace DizzyProxy.Exceptions
{
    public class InternalServerErrorException : ApiException
    {
        public InternalServerErrorException(int code) : base(code) { }
        public InternalServerErrorException(int code, string message) : base(code, message) { }
        public InternalServerErrorException(int code, string message, Exception inner) : base(code, message, inner) { }
    }
}