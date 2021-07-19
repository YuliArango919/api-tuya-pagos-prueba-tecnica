using System;
using System.Net;

namespace App.Tuya.Pagos.Common.Handler
{
    [Serializable()]
    public class StatusCodeException : Exception
    {
        public StatusCodeException() : base() { }
        public StatusCodeException(HttpStatusCode StatusCode, string message)
            : base(message)
        {
            this.HResult = (int)StatusCode;
        }
        public StatusCodeException(string message, System.Exception inner) : base(message, inner) { }
    }
}
