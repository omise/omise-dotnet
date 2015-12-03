using System;
using System.Net;

namespace Omise {
    public class OmiseException : Exception {
        public ErrorResult Result { get; private set; }
        public HttpStatusCode StatusCode { get; protected internal set; }

        public string Location { get { return Result.Location; } }
        public string Code { get { return Result.Code; } }
        public string OmiseMessage { get { return Result.Message; } }

        public OmiseException(
            Exception inner,
            HttpStatusCode statusCode,
            ErrorResult result) : base("Omise Error", inner) {
            StatusCode = statusCode;
            Result = result;
        }
    }
}

