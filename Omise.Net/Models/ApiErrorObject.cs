using System;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Omise
{
    /// <summary>
    /// Represents the properties of API error information
    /// </summary>
    [Serializable]
    public class ApiErrorObject
    {
        private string location;

        /// <summary>
        /// URL of error documentation.
        /// </summary>
        /// <value>The location.</value>
        public string Location
        {
            get { return location; }
        }

        private string code;

        /// <summary>
        /// Error code
        /// </summary>
        public string Code
        {
            get { return code; }
        }

        private string message;

        /// <summary>
        /// Error message
        /// </summary>
        public string Message
        {
            get { return message; }
        }

        private string rawMessage;

        /// <summary>
        /// Raw error message
        /// </summary>
        public string RawMessage
        {
            get { return rawMessage; }
        }

        /// <summary>
        /// Initializes the ApiErrorObject object 
        /// </summary>
        /// <param name="resultString"></param>
        public ApiErrorObject(string resultString)
        {
            rawMessage = resultString;
            try
            {
                var errorObj = JObject.Parse(resultString);
                location = errorObj["location"].ToString();
                code = errorObj["code"].ToString();
                message = errorObj["message"].ToString();
            }
            catch
            {
                message = "Unable to parse error result. See RawMessage for detail.";
            }
        }

        /// <summary>
        /// Returns a string representing the api error message
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return message;
        }
    }
}

