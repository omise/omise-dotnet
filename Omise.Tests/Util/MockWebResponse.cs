using System;
using System.IO;
using System.Net;
using System.Text;

namespace Omise.Tests.Util {
    public class MockWebResponse : WebResponse {
        readonly byte[] buffer;
        readonly long contentLength;
        readonly string contentType;
        readonly Uri responseUri;

        public override long ContentLength { get { return contentLength; } }
        public override string ContentType { get { return contentType; } }
        public override Uri ResponseUri { get { return responseUri; } }

        public WebRequest Request { get; private set; }

        public MockWebResponse(MockRoundtripper roundtripper, WebRequest request) {
            buffer = Encoding.Unicode.GetBytes(roundtripper.ResponseContent);
            contentType = roundtripper.ResponseContentType;
            contentLength = buffer.Length;
            responseUri = request.RequestUri;

            Request = request;
        }

        public override Stream GetResponseStream() {
            return new MemoryStream(buffer);
        }
    }
}

