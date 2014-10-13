using System;
using System.Net;
using System.IO;
using System.Text;
using System.Security.Permissions;
using System.Runtime.Serialization;

namespace Omise
{
	/// <summary>
	/// ApiException will be thrown when there is any error requesting the Omise api.
	/// </summary>
	[Serializable]
	public sealed class ApiException: Exception
	{
		private static string defaultMessage = "There was an error requesting the API. {0}";
		private WebException webException;
		private ApiErrorObject apiErrorObject;
        /// <summary>
        /// Http status code
        /// </summary>
		public HttpStatusCode StatusCode{ get; set; }
		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.ApiException"/> class.
		/// </summary>
		public ApiException(){
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Omise.ApiException"/> class.
		/// </summary>
		/// <param name="webException">Web exception.</param>
		public ApiException(WebException webException): base(defaultMessage, webException){
			this.webException = webException;
			if (webException.Response != null) {
				using (var sr = new StreamReader (webException.Response.GetResponseStream (), true)) {
					var errorResult = new StringBuilder ();
					string line;
					while ((line = sr.ReadLine ()) != null) {
						errorResult.AppendLine (line);
					}

					apiErrorObject = new ApiErrorObject (errorResult.ToString ());
				}
				StatusCode = ((HttpWebResponse)webException.Response).StatusCode;
			}
		}

		/// <summary>
		/// Gets the API error object.
		/// </summary>
		/// <value>The API error object.</value>
		public ApiErrorObject ApiErrorObject{ 
			get{ return apiErrorObject; }
		}

		/// <summary>
		/// Return error message of the exception
		/// </summary>
		/// <value>The error message.</value>
		public override string Message {
			get {
				if (apiErrorObject != null) {
					return string.Format (defaultMessage, apiErrorObject.ToString ());
				} else if (webException != null) {
					return string.Format (defaultMessage, webException.Message);
				} else {
					return defaultMessage;
				}
			}
		}

		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		private ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this.apiErrorObject = info.GetValue("ApiErrorObject", typeof(ApiErrorObject)) as ApiErrorObject;
		}

		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}

			info.AddValue("ApiErrorObject", this.ApiErrorObject);

			// MUST call through to the base class to let it save its own state
			base.GetObjectData(info, context);
		}
	}
}

