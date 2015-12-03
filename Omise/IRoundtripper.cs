using System.Net;
using System.Threading.Tasks;

namespace Omise {
    public interface IRoundtripper {
        WebRequest CreateRequest(string uri);
        Task<WebResponse> Roundtrip(WebRequest request);
    }
}

