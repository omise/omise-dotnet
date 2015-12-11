using System;
using System.Net;
using Omise.Tests.Util;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace Omise.Tests.Util {
    public class FixturesWebResponse : WebResponse {
        readonly byte[] responseData;
        readonly Uri responseUri;

        public override long ContentLength { get { return responseData.Length; } }
        public override string ContentType { get { return "application/json"; } }
        public override Uri ResponseUri { get { return responseUri; } }

        public WebRequest Request { get; private set; }

        public FixturesWebResponse(WebRequest request) {
            var method = request.Method.ToLower();
            var host = request.RequestUri.Host;
            var path = request.RequestUri.AbsolutePath;

            var filename = "fixtures/" + host + path + "-" + method + ".json";
            if (!TestData.Files.ContainsKey(filename)) {
                var segments = path.Split('/');
                segments[segments.Length - 1] = "404";

                filename = "fixtures/" + host + string.Join("/", segments) + "-" + method + ".json";
            }

            if (!TestData.Files.ContainsKey(filename)) {
                Debugger.Break();
            }

            responseUri = request.RequestUri;
            responseData = TestData.Files[filename];

            Request = request;
        }

        public override Stream GetResponseStream() {
            return new MemoryStream(responseData, 0, responseData.Length, false);
        }
    }
}

