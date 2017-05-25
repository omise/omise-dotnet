using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Omise.Models;
using System.IO;
using System.Text;

namespace Omise
{
    public class Requester : IRequester
    {
        readonly string userAgent;

        public Credentials Credentials { get; private set; }
        public string APIVersion { get; set; }

        public IRoundtripper Roundtripper { get; private set; }
        public Serializer Serializer { get; private set; }

        public Requester(
            Credentials creds,
            IRoundtripper roundtripper = null,
            string apiVersion = null
        )
        {
            if (creds == null) throw new ArgumentNullException(nameof(creds));

            userAgent = buildRequestMetadata()
                .Aggregate("", (acc, pair) => $"{acc} {pair.Key}/{pair.Value}")
                .Trim();

            Credentials = creds;
            APIVersion = apiVersion;

            Roundtripper = roundtripper ?? new DefaultRoundtripper();
            Serializer = new Serializer();
        }

        IDictionary<string, string> buildRequestMetadata()
        {
            var thisAsmName = GetType().GetTypeInfo().Assembly.GetName();
            var clrAsmName = typeof(object).GetTypeInfo().Assembly.GetName();

            return new Dictionary<string, string>
            {
                { "Omise.Net", thisAsmName.Version.ToString() },
                { ".Net", clrAsmName.Version.ToString() },
            };
        }


        public async Task<TResult> Request<TResult>(
            Endpoint endpoint,
            string method,
            string path)
            where TResult : class
        {
            return await Request<object, TResult>(endpoint, method, path, null);
        }

        public async Task<TResult> Request<TPayload, TResult>(
            Endpoint endpoint,
            string method,
            string path,
            TPayload payload)
            where TPayload : class
            where TResult : class
        {

            var key = endpoint.KeySelector(Credentials);

            // creates initial request
            // TODO: Dispose request.
            var request = Roundtripper.CreateRequest(method, endpoint.ApiPrefix + path);
            request.Headers.Add("Authorization", key.EncodeForAuthorizationHeader());
            request.Headers.Add("User-Agent", userAgent);

            if (!string.IsNullOrEmpty(APIVersion)) request.Headers.Add("Omise-Version", APIVersion);
            if (payload != null)
            {
                using (var ms = new MemoryStream())
                {
                    Serializer.JsonSerialize(ms, payload);

                    var buffer = ms.ToArray();
                    var content = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                }
            }

            // roundtrips the request
            try
            {
                var response = await Roundtripper.Roundtrip(request);
                var stream = await response.Content.ReadAsStreamAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var error = Serializer.JsonDeserialize<ErrorResult>(stream);
                    error.HttpStatusCode = response.StatusCode;
                    throw new OmiseError(error, null);
                }

                var result = Serializer.JsonDeserialize<TResult>(stream);
                var model = result as ModelBase;
                if (model != null)
                {
                    model.Requester = this;
                }

                return result;

            }
            catch (HttpRequestException e)
            {
                throw new OmiseException("Error while making HTTP request", e);
            }
        }
    }
}