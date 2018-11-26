using System;

namespace DizzyProxy.Exceptions
{
    public class BadRequestException : ApiException
    {
        public BadRequestException(int code) : base(code) {}
        public BadRequestException(int code, string message) : base(code, message) {}
        public BadRequestException(int code, string message, Exception inner) : base(code, message, inner) {}
    }
}