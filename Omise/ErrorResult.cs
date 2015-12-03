using System;

namespace Omise {
    public class ErrorResult {
        public string Location { get; protected internal set; }
        public string Code { get; protected internal set; }
        public string Message { get; protected internal set; }
    }
}

