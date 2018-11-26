using System;

namespace DizzyProxy.Exceptions
{
    public class UnauthorizedException : ApiException
    {
        public UnauthorizedException(int code) : base(code) { }
        public UnauthorizedException(int code, string message) : base(code, message) { }
        public UnauthorizedException(int code, string message, Exception inner) : base(code, message, inner) { }
    }
}