using System;
using System.Net;
using System.Threading.Tasks;

namespace Omise {
    public class DefaultRoundtripper : IRoundtripper {
        public WebRequest CreateRequest(string uri) {
            return WebRequest.CreateHttp(uri);
        }

        public Task<WebResponse> Roundtrip(WebRequest request) {
            return Task<WebResponse>.Factory.FromAsync(
                request.BeginGetResponse,
                request.EndGetResponse,
                null
            );
        }
    }
}

