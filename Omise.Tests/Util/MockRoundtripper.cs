using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Omise.Tests.Util {
    public delegate void RequestInspector(HttpRequestMessage request);
    public delegate void ResponseInspector(HttpResponseMessage response);

    public sealed class MockRoundtripper : IRoundtripper {
        public string ResponseContentType { get; set; }
        public string ResponseContent { get; set; }

        public RequestInspector RequestInspector { get; set; }
        public ResponseInspector ResponseInspector { get; set; }

        public int RoundtripCount { get; set; }

        public MockRoundtripper(
            RequestInspector requestInspector = null,
            ResponseInspector responseInspector = null) {
            ResponseContent = "{}";
            ResponseContentType = "application/json";
            RequestInspector = requestInspector;
            ResponseInspector = responseInspector;
            RoundtripCount = 0;
        }

        public HttpRequestMessage CreateRequest(string method, string uri) {
            return new HttpRequestMessage(new HttpMethod(method), uri);
        }

        public Task<HttpResponseMessage> Roundtrip(HttpRequestMessage request) {
            if (RequestInspector != null) {
                RequestInspector(request);
            }

            RoundtripCount += 1;
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(
                ResponseContent,
                Encoding.UTF8,
                ResponseContentType
            );

            if (ResponseInspector != null) {
                ResponseInspector(response);
            }

            var source = new TaskCompletionSource<HttpResponseMessage>();
            source.SetResult(response);
            return source.Task;
        }

    }
}

