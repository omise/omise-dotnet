using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System;

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

            var filename = $"{host}{path}-{method}.json";
            var fullpath = Fixtures.GetFixturesPath(filename);

            if (!File.Exists(fullpath))
            {
                var segments = path.Split('/');
                segments[segments.Length - 1] = "404";

                response.StatusCode = HttpStatusCode.NotFound;
                filename = $"{host}{string.Join("/", segments)}-{method}.json";
                fullpath = Fixtures.GetFixturesPath(filename);
            }

            if (!File.Exists(fullpath))
            {
                Debugger.Break();
            }

            var bytes = File.ReadAllBytes(fullpath);
            response.Content = new ByteArrayContent(bytes);
            response.Content.Headers.Add("Content-Type", "application/json");
            return response;
        }
    }
}

