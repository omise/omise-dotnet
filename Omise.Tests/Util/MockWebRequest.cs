using System;
using System.Net;
using System.IO;

namespace Omise.Tests.Util {
    public class MockWebRequest : WebRequest {
        public readonly MockRoundtripper Roundtripper;
        public readonly MemoryStream RequestStream;
        public readonly Uri Uri;

        public override Uri RequestUri { get { return Uri; } }
        public override string Method { get; set; }

        public override WebHeaderCollection Headers { get; set; }
        public override string ContentType { get; set; }


        public MockWebRequest(MockRoundtripper roundtripper, string uri) {
            Roundtripper = roundtripper;
            RequestStream = new MemoryStream();
            Uri = new Uri(uri);
            Method = "GET";

            Headers = new WebHeaderCollection();
            ContentType = "application/json";
        }

        public override void Abort() {
            throw new NotImplementedException();
        }

        public override IAsyncResult BeginGetRequestStream(
            AsyncCallback callback,
            object state) {
            var ar = new AsyncResult<Stream>(RequestStream);
            callback.BeginInvoke(ar, callback.EndInvoke, null);
            return ar;
        }

        public override Stream EndGetRequestStream(IAsyncResult asyncResult) {
            return ((AsyncResult<Stream>)asyncResult).Result;
        }

        public override IAsyncResult BeginGetResponse(
            AsyncCallback callback,
            object state) {
            var ar = new AsyncResult<WebResponse>(new MockWebResponse(Roundtripper, this));
            callback.BeginInvoke(ar, callback.EndInvoke, null);
            return ar;
        }

        public override WebResponse EndGetResponse(IAsyncResult asyncResult) {
            return ((AsyncResult<WebResponse>)asyncResult).Result;
        }

    }
}

