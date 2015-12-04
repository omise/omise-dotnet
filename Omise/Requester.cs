using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
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

        public async Task<TResult> Request<TResult>(
            Endpoint endpoint,
            string method,
            string path)
            where TResult : class {
            return await Request<object, TResult>(endpoint, method, path, null);
        }

        public async Task<TResult> Request<TPayload, TResult>(
            Endpoint endpoint,
            string method,
            string path,
            TPayload payload)
            where TPayload : class
            where TResult : class {

            var key = endpoint.KeySelector(Credentials);
        
            // creates initial request
            var request = Roundtripper.CreateRequest(endpoint.ApiPrefix + path);
            request.Method = method;
            request.Headers["Authorization"] = key.EncodeForAuthorizationHeader();

            if (payload != null) {
                using (var requestStream = await Task.Factory.FromAsync<Stream>(
                                               request.BeginGetRequestStream,
                                               request.EndGetRequestStream,
                                               null
                                           )) {
                    JsonSerialize(requestStream, payload);
                }
            }

            // roundtrips the request
            try {
                var response = await Roundtripper.Roundtrip(request);
                using (var stream = response.GetResponseStream()) {
                    return JsonDeserialize<TResult>(stream);
                }

            } catch (WebException e) {
                var errorResult = JsonDeserialize<ErrorResult>(e.Response.GetResponseStream());
                var code = (HttpStatusCode)0;

                var httpResponse = e.Response as HttpWebResponse;
                if (httpResponse != null) {
                    code = httpResponse.StatusCode;
                }

                throw new OmiseException(e, code, errorResult);
            }
        }


        void JsonSerialize<T>(Stream target, T payload) where T: class {
            using (var writer = new StreamWriter(target))
            using (var jsonWriter = new JsonTextWriter(writer)) {
                JsonSerializer.Serialize(jsonWriter, payload);
            }
        }

        T JsonDeserialize<T>(Stream source) where T: class {
            using (var reader = new StreamReader(source))
            using (var jsonReader = new JsonTextReader(reader)) {
                return JsonSerializer.Deserialize<T>(jsonReader);
            }
        }
    }
}

