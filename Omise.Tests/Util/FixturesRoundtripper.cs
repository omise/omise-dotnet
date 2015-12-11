using System;
using System.Net;
using System.Threading.Tasks;

namespace Omise.Tests.Util {
    public class FixturesRoundtripper : IRoundtripper {
        public WebRequest CreateRequest(string uri) {
            return new FixturesWebRequest(this, uri);
        }

        public Task<WebResponse> Roundtrip(WebRequest request) {
            var result = new TaskCompletionSource<WebResponse>();
            result.SetResult(new FixturesWebResponse(request)); 
            return result.Task;
        }
    }
}

