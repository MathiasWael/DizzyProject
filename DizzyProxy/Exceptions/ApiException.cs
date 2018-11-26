using System;
using System.Net;

namespace DizzyProxy.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public int ErrorCode { get; private set; }

        public ApiException(HttpStatusCode statusCode, int errorCode)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
        }

        public ApiException(HttpStatusCode statusCode, int errorCode, string message) : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
        }

        public ApiException(HttpStatusCode statusCode, int errorCode, string message, Exception inner) : base(message, inner)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
        }
    }
}