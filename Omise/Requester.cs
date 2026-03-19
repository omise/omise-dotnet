using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Omise.Models;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace Omise
{
    public class Requester : IRequester
    {
        readonly string userAgent;

        public Credentials Credentials { get; private set; }
        public string APIVersion { get; set; }

        public IRoundtripper Roundtripper { get; private set; }
        public IEnvironment Environment { get; private set; }
        public Serializer Serializer { get; private set; }

        public Requester(
            Credentials creds,
            IEnvironment env,
            IRoundtripper roundtripper = null,
            string apiVersion = null
        )
        {
            if (creds == null) throw new ArgumentNullException(nameof(creds));
            if (env == null) throw new ArgumentNullException(nameof(env));

            userAgent = buildRequestMetadata()
                .Aggregate("", (acc, pair) => $"{acc} {pair.Key}/{pair.Value}")
                .Trim();

            Credentials = creds;
            APIVersion = apiVersion;
            Environment = env;

            Roundtripper = roundtripper ?? new DefaultRoundtripper();
            Serializer = new Serializer();
        }

        IDictionary<string, string> buildRequestMetadata()
        {
            var libAsm = typeof(Requester).Assembly;
            var libVersion = libAsm
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion ?? libAsm.GetName().Version.ToString();

            // Some pipelines might use the commit hash in the version which is typical in dotnet builds but we do not want to include that in the user agent
            if (libVersion.Contains("+"))
            {
                libVersion = libVersion.Substring(0, libVersion.IndexOf("+"));
            }

            return new Dictionary<string, string>
            {
                { "Omise.Net", libVersion },
                { ".Net", RuntimeInformation.FrameworkDescription },
            };
        }


        public async Task<TResult> Request<TResult>(
            Endpoint endpoint,
            string method,
            string path)
            where TResult : class
        {
            return await Request<object, TResult>(endpoint, method, path, null, null);
        }

        public async Task<TResult> Request<TPayload, TResult>(
            Endpoint endpoint,
            string method,
            string path,
            TPayload payload)
            where TPayload : class
            where TResult : class
        {
            return await Request<TPayload, TResult>(endpoint, method, path, payload, null);
        }

        public async Task<TResult> Request<TResult>(
            Endpoint endpoint,
            string method,
            string path,
            IDictionary<string, string> customHeaders)
            where TResult : class
        {
            return await Request<object, TResult>(endpoint, method, path, null, customHeaders);
        }

        public async Task<TResult> Request<TPayload, TResult>(
            Endpoint endpoint,
            string method,
            string path,
            TPayload payload,
            IDictionary<string, string> customHeaders)
            where TPayload : class
            where TResult : class
        {
            var apiPrefix = Environment.ResolveEndpoint(endpoint);
            var key = Environment.SelectKey(endpoint, Credentials);

            // creates initial request
            // TODO: Dispose request.
            var request = Roundtripper.CreateRequest(method, apiPrefix + path);
            SetHeaders(request, key, customHeaders);

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
        private void SetHeaders(HttpRequestMessage request, Key key, IDictionary<string, string> customHeaders)
        {
            request.Headers.Add("Authorization", key.EncodeForAuthorizationHeader());
            request.Headers.Add("User-Agent", userAgent);
            if (customHeaders != null)
            {
                foreach (var header in customHeaders)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
        }
    }
}
