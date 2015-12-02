using System;
using System.Net;
using System.IO;
using System.Text;
using Omise.Net;

namespace Omise
{
    /// <summary>
    /// Default Request manager object implementing IRequestManager interface.
    /// </summary>
    public class RequestManager : IRequestManager
    {
        private Credentials credentials;
        private Endpoint endpoint;
        private string apiVersion;

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.RequestManager"/> class.
        /// </summary>
        /// <param name="apiUrlBase">Api base URL</param>
        /// <param name="apiKey">Api key</param>
        public RequestManager(string apiUrlBase, string apiKey)
        {
            if (string.IsNullOrEmpty(apiUrlBase))
                throw new ArgumentNullException("apiUrlBase");
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException("apiKey");

            var endpoint = Endpoint.From(apiUrlBase);
            if (endpoint == null)
                throw new ArgumentException("unrecognized endpoint.", "apiUrlBase");

            this.credentials = new Credentials(null, skey: apiKey);
            this.endpoint = endpoint;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.RequestManager"/> class.
        /// </summary>
        /// <param name="apiUrlBase">Api base URL</param>
        /// <param name="apiKey">Api key</param>
        /// <param name="apiVersion">Api version</param>
        public RequestManager(string apiUrlBase, string apiKey, string apiVersion)
        {
            if (string.IsNullOrEmpty(apiUrlBase))
                throw new ArgumentNullException("apiUrlBase");
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException("apiKey");

            var endpoint = Endpoint.From(apiUrlBase);
            if (endpoint == null)
                throw new ArgumentException("unrecognized endpoint.", "apiUrlBase");

            this.credentials = new Credentials(null, skey: apiKey);
            this.endpoint = endpoint;
            this.apiVersion = apiVersion;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.RequestManager"/> class.
        /// </summary>
        /// <param name="endpoint">Endpoint.</param>
        /// <param name="credentials">Credentials.</param>
        /// <param name="apiVersion">API version.</param>
        internal RequestManager(Endpoint endpoint, Credentials credentials, string apiVersion)
        {
            if (endpoint == null)
                throw new ArgumentNullException("endpoint");
            if (credentials == null)
                throw new ArgumentNullException("credentials");
            
            this.endpoint = endpoint;
            this.credentials = credentials;
            this.apiVersion = apiVersion;
        }

        /// <summary>
        /// Executes the request and return result string
        /// </summary>
        /// <returns>Response string</returns>
        /// <param name="path">Path</param>
        /// <param name="method">Method</param>
        /// <param name="payload">Request payload</param>
        public string ExecuteRequest(string path, string method, string payload)
        {
            var key = endpoint.SelectKey(credentials);

            StringBuilder result = new StringBuilder();
            path = path.StartsWith("/") ? path : "/" + path;

            var request = (HttpWebRequest)WebRequest.Create(endpoint.Host + path);
            request.Headers.Add("Authorization", key.AuthorizationHeader());

            if (!string.IsNullOrEmpty(this.apiVersion) && this.apiVersion.Trim().Length > 0)
            {
                request.Headers.Add("Omise-Version", this.apiVersion);
            }

            request.UserAgent = "Omise.Net/" + Omise.VersionInfo.ClientVersion;
            request.Method = method;
            request.ContentType = "application/x-www-form-urlencoded";
            if (payload != null)
            {
                byte[] data = Encoding.UTF8.GetBytes(payload);
                try
                {
                    using (Stream reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(data, 0, data.Length);
                    }
                }
                catch (WebException ex)
                {
                    throw new ApiException(ex);
                }
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            result.AppendLine(line);
                        }
                    }
                }

                return result.ToString();
            }
            catch (WebException ex)
            {
                throw new ApiException(ex);
            }
        }
    }
}

