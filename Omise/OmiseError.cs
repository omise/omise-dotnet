using System;
using System.Net;

namespace Omise
{
    public class OmiseError : OmiseException
    {
        public ErrorResult Error { get; private set; }
        public HttpStatusCode HttpStatusCode { get { return Error.HttpStatusCode; } }
        public string Location { get { return Error.Location; } }
        public string Code { get { return Error.Code; } }
        public override string Message { get { return Error.Message; } }

        public OmiseError(
            ErrorResult result,
            Exception inner
        ) : base("API call result in an error.", inner)
        {
            Error = result;
        }

        public override string ToString() => $"({(int)HttpStatusCode}/{Code}) {Error.Message}";
    }
}