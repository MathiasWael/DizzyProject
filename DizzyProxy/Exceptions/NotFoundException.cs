using System;

namespace DizzyProxy.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(int code) : base(code) { }
        public NotFoundException(int code, string message) : base(code, message) { }
        public NotFoundException(int code, string message, Exception inner) : base(code, message, inner) { }
    }
}