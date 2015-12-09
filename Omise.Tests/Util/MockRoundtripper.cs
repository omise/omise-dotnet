using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;

namespace Omise.Tests.Util {
    public sealed class MockRoundtripper : IRoundtripper {
        public string ResponseContentType { get; set; }
        public string ResponseContent { get; set; }

        public Action<WebRequest> RequestInspector { get; set; }
        public Action<WebResponse> ResponseInspector { get; set; }

        public int RoundtripCount { get; set; }

        public MockRoundtripper(
            Action<WebRequest> requestInspector = null,
            Action<WebResponse> responseInspector = null) {
            ResponseContent = "{}";
            ResponseContentType = "application/json";
            RequestInspector = requestInspector;
            ResponseInspector = responseInspector;
            RoundtripCount = 0;
        }

        public WebRequest CreateRequest(string uri) {
            return new MockWebRequest(this, uri);
        }

        public Task<WebResponse> Roundtrip(WebRequest request) {
            if (RequestInspector != null) {
                RequestInspector(request);
            }

            RoundtripCount += 1;
            var task = Task<WebResponse>.Factory.FromAsync(
                           request.BeginGetResponse,
                           request.EndGetResponse,
                           null
                       );

            if (ResponseInspector != null) {
                task = task.ContinueWith<WebResponse>(task1 => {
                        var response = task1.Result;
                        ResponseInspector(response);
                        return response;
                    });
            }

            return task;
        }
    }
}

