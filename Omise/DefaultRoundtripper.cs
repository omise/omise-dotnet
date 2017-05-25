using System.Net.Http;
using System.Threading.Tasks;

namespace Omise
{
    public class DefaultRoundtripper : IRoundtripper
    {
        readonly HttpClient client = new HttpClient();

        public HttpRequestMessage CreateRequest(string method, string uri)
        {
            return new HttpRequestMessage(new HttpMethod(method), uri);
        }

        public Task<HttpResponseMessage> Roundtrip(HttpRequestMessage request)
        {
            return client.SendAsync(request);
        }
    }
}