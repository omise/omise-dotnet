using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace Omise {
    public class Requester : IRequester {
        internal IRoundtripper Roundtripper { get; set; }
        
        public Credentials Credentials { get; private set; }
        public JsonSerializer JsonSerializer { get; private set; }

        public Requester(Credentials creds) {
            if (creds == null) throw new ArgumentNullException("creds");

            Credentials = creds;
            Roundtripper = new DefaultRoundtripper();
            JsonSerializer = new JsonSerializer();
        }

        public Task<TResult> Request<TResult>(
            Endpoint endpoint,
            string method,
            string path)
            where TResult : class {
            return Request<object, TResult>(endpoint, method, path, null);
        }

        public Task<TResult> Request<TPayload, TResult>(
            Endpoint endpoint,
            string method,
            string path,
            TPayload payload)
            where TPayload : class
            where TResult : class {

            var key = endpoint.KeySelector(Credentials);
            var serializer = new JsonSerializer();
        
            var request = Roundtripper.CreateRequest(endpoint.ApiPrefix + path);
            request.Method = method;
            request.Headers["Authorization"] = key.EncodeForAuthorizationHeader();

            Task<WebRequest> requestTask;
            if (payload == null) {
                var source = new TaskCompletionSource<WebRequest>();
                source.SetResult(request);
                requestTask = source.Task;

            } else {
                requestTask = Task<Stream>.Factory.FromAsync(
                    request.BeginGetRequestStream,
                    request.EndGetRequestStream,
                    null
                ).ContinueWith<WebRequest>(task1 => {
                        using (var requestStream = task1.Result)
                        using (var sw = new StreamWriter(requestStream))
                        using (var writer = new JsonTextWriter(sw)) {
                            serializer.Serialize(writer, payload);
                        }

                        return request;
                    });
            }

            return requestTask
                .ContinueWith<WebResponse>(task1 => Roundtripper.Roundtrip(task1.Result).Result)
                .ContinueWith<WebResponse>(task3 => {
                    var firstException = task3.Exception.Flatten().InnerException;
                    var webException = firstException as WebException;
                    if (webException == null) throw task3.Exception;

                    using (var stream = webException.Response.GetResponseStream())
                    using (var sr = new StreamReader(stream))
                    using (var reader = new JsonTextReader(sr)) {
                        var result = serializer.Deserialize<ErrorResult>(reader);
                        var code = (HttpStatusCode)0;

                        var httpResponse = webException.Response as HttpWebResponse;
                        if (httpResponse != null) code = httpResponse.StatusCode;   

                        throw new OmiseException(task3.Exception, code, result);
                    }
                }, TaskContinuationOptions.OnlyOnFaulted)

            // parse succesful responses.
                .ContinueWith<Stream>(task => {
                    var response = task.Result;
                    if (response == null) return null;

                    return response.GetResponseStream();
                })
                .ContinueWith<TResult>(task => {
                    using (var stream = task.Result)
                    using (var sr = new StreamReader(stream))
                    using (var reader = new JsonTextReader(sr)) {
                        return serializer.Deserialize<TResult>(reader);
                    }
                });
        }
    }
}

