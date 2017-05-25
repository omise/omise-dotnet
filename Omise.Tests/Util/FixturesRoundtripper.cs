using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Omise.Tests.Util
{
    public class FixturesRoundtripper : IRoundtripper
    {
        public HttpRequestMessage CreateRequest(string method, string uri)
        {
            return new HttpRequestMessage(new HttpMethod(method), uri);
        }

        public Task<HttpResponseMessage> Roundtrip(HttpRequestMessage request)
        {
            var response = FixedResponseFor(request);

            var source = new TaskCompletionSource<HttpResponseMessage>();
            source.SetResult(response);
            return source.Task;
        }

        private HttpResponseMessage FixedResponseFor(HttpRequestMessage request)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var method = request.Method.ToString().ToLower();
            var host = request.RequestUri.Host;
            var path = request.RequestUri.AbsolutePath;

            var filename = $"fixtures/{host}{path}-{method}.json";
            if (!TestData.Files.ContainsKey(filename))
            {
                var segments = path.Split('/');
                segments[segments.Length - 1] = "404";

                response.StatusCode = HttpStatusCode.NotFound;
                filename = $"fixtures/{host}{string.Join("/", segments)}-{method}.json";
            }

            if (!TestData.Files.ContainsKey(filename))
            {
                Debugger.Break();
            }

            var data = TestData.Files[filename];
            response.Content = new ByteArrayContent(data);
            response.Content.Headers.Add("Content-Type", "application/json");
            return response;
        }
    }
}

