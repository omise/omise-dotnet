using System;
using System.Net;
using System.IO;
using System.Text;

namespace Omise
{
    /// <summary>
    /// Default Request manager object implementing IRequestManager interface.
    /// </summary>
    public class RequestManager : IRequestManager
    {
        private string apiUrlBase;
        private string apiKey;
        private string encodedCredentials;

        /// <summary>
        /// Initializes a new instance of the <see cref="Omise.RequestManager"/> class.
        /// </summary>
        /// <param name="apiUrlBase">API base URL</param>
        /// <param name="apiKey">API key</param>
        public RequestManager(string apiUrlBase, string apiKey)
        {
            if (string.IsNullOrEmpty(apiUrlBase))
                throw new ArgumentNullException("apiUrlBase");
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException("apiKey");
            this.apiUrlBase = apiUrlBase;
            this.apiKey = apiKey;
            this.encodedCredentials = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(this.apiKey + ":"));
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
            StringBuilder result = new StringBuilder();
            path = path.StartsWith("/") ? path : "/" + path;

            var request = WebRequest.Create(apiUrlBase + path);
            request.Headers.Add("Authorization", "Basic " + this.encodedCredentials);
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

