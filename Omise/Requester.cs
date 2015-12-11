using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;
using Omise.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Omise {
    public class Requester : IRequester {
        readonly string userAgent;

        public IRoundtripper Roundtripper { get; private set; }

        public Credentials Credentials { get; private set; }
        public Serializer Serializer { get; private set; }

        public Requester(Credentials creds, IRoundtripper roundtripper = null) {
            if (creds == null) throw new ArgumentNullException("creds");

            var metadata = new Dictionary<string, string>
            {
                { "Omise.Net", new AssemblyName(GetType().Assembly.FullName).Version.ToString() },
                { ".Net", new AssemblyName(typeof(object).Assembly.FullName).Version.ToString() },
            };

            userAgent = metadata.Aggregate("", (acc, pair) => acc + " " + pair.Key + "/" + pair.Value).Trim();
            Credentials = creds;
            Roundtripper = roundtripper ?? new DefaultRoundtripper();
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
            // TODO: Dispose request.
            var request = Roundtripper.CreateRequest(method, endpoint.ApiPrefix + path);
            request.Headers.Add("Authorization", key.EncodeForAuthorizationHeader());
            request.Headers.Add("User-Agent", userAgent);

            if (payload != null) {
                request.Content = Serializer.ExtractFormValues(payload);
            }

            // roundtrips the request
            try {
                var response = await Roundtripper.Roundtrip(request);
                var stream = await response.Content.ReadAsStreamAsync();
                if (!response.IsSuccessStatusCode) {
                    var error = Serializer.JsonDeserialize<ErrorResult>(stream);
                    error.HttpStatusCode = response.StatusCode;
                    throw new OmiseError(error, null);
                }

                var result = Serializer.JsonDeserialize<TResult>(stream);
                var model = result as ModelBase;
                if (model != null) {
                    model.Requester = this;
                }

                return result;

            } catch (HttpRequestException e) {
                throw new OmiseException("Error while making HTTP request", e);
            }
        }
    }
}

