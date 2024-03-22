﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Omise.Tests.Util
{
    // Records IRequester.Request calls
    public class RequestAttempt
    {
        public Endpoint Endpoint { get; internal set; }
        public string Method { get; internal set; }
        public string Path { get; internal set; }

        public MemoryStream RequestStream { get; internal set; }
        public Type PayloadType { get; internal set; }
        public IDictionary<string, string> Headers;
        public object Payload { get; internal set; }

        public Type ResultType { get; internal set; }
        public object Result { get; internal set; }
    }
}

