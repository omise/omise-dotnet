using System;
using System.Threading;
using System.Net;
using System.IO;

namespace Omise.Tests.Util {
    public class FixturesWebRequest : WebRequest {
        public readonly FixturesRoundtripper Roundtripper;
        public readonly Uri Uri;

        public override Uri RequestUri { get { return Uri; } }
        public override string Method { get; set; }

        public override WebHeaderCollection Headers { get; set; }
        public override string ContentType { get; set; }

        public FixturesWebRequest(FixturesRoundtripper roundtripper, string uri) {
            Roundtripper = roundtripper;
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
            var ar = new AsyncResult<Stream>(new MemoryStream());
            callback.BeginInvoke(ar, callback.EndInvoke, null);
            return ar;
        }
            
        public override System.IO.Stream EndGetRequestStream(IAsyncResult asyncResult) {
            return ((AsyncResult<Stream>)asyncResult).Result;
        }

        public override IAsyncResult BeginGetResponse(
            AsyncCallback callback,
            object state) {
            var ar = new AsyncResult<WebResponse>(new FixturesWebResponse(this));
            callback.BeginInvoke(ar, callback.EndInvoke, null);
            return ar;
        }

        public override WebResponse EndGetResponse(IAsyncResult asyncResult) {
            return ((AsyncResult<WebResponse>)asyncResult).Result;
        }

    }
}

