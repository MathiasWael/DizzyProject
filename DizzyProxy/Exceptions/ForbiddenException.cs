using System;

namespace DizzyProxy.Exceptions
{
    public class ForbiddenException : ApiException
    {
        public ForbiddenException(int code) : base(code) { }
        public ForbiddenException(int code, string message) : base(code, message) { }
        public ForbiddenException(int code, string message, Exception inner) : base(code, message, inner) { }
    }
}