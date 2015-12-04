using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Omise {
    public class Requester : IRequester {
        internal IRoundtripper Roundtripper { get; set; }
        
        public Credentials Credentials { get; private set; }
        public Serializer Serializer { get; private set; }

        public Requester(Credentials creds) {
            if (creds == null) throw new ArgumentNullException("creds");

            Credentials = creds;
            Roundtripper = new DefaultRoundtripper();
            Serializer = new Serializer();
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
            request.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            request.Headers["Authorization"] = key.EncodeForAuthorizationHeader();

            if (payload != null) {
                using (var requestStream = await Task.Factory.FromAsync<Stream>(
                                               request.BeginGetRequestStream,
                                               request.EndGetRequestStream,
                                               null
                                           )) {
                    Serializer.FormSerialize(requestStream, payload);
                }
            }

            // roundtrips the request
            try {
                var response = await Roundtripper.Roundtrip(request);
                using (var stream = response.GetResponseStream()) {
                    return Serializer.JsonDeserialize<TResult>(stream);
                }

            } catch (WebException e) {
                var errorResult = Serializer.JsonDeserialize<ErrorResult>(e.Response.GetResponseStream());
                var code = (HttpStatusCode)0;

                var httpResponse = e.Response as HttpWebResponse;
                if (httpResponse != null) {
                    code = httpResponse.StatusCode;
                }

                throw new OmiseException(e, code, errorResult);
            }
        }
    }
}

