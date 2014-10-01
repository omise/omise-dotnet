using System;
using System.Net;
using System.IO;
using System.Text;

namespace Omise
{
	public class ApiException: Exception
	{
		private string defaultMessage = "There was an error requesting the API. {0}";
		private WebException webException;
		private ApiErrorObject apiErrorObject;
		public HttpStatusCode StatusCode{ get; set; }

		public ApiException(WebException ex){
			webException = ex;
			if (webException.Response != null) {
				using (var sr = new StreamReader (webException.Response.GetResponseStream (), true)) {
					StringBuilder errorResult = new StringBuilder ();
					string line;
					while ((line = sr.ReadLine ()) != null) {
						errorResult.AppendLine (line);
					}

					apiErrorObject = new ApiErrorObject (errorResult.ToString ());
				}
				StatusCode = ((HttpWebResponse)ex.Response).StatusCode;
			}
		}

		public ApiErrorObject ApiErrorObject{ 
			get{ return apiErrorObject; }
		}

		public override Exception GetBaseException ()
		{
			return webException;
		}

		public override string Message {
			get {
				return string.Format(defaultMessage, apiErrorObject==null? webException.Message : apiErrorObject.ToString ());
			}
		}

//		public NetworkException(string message): base(string.Format(defaultMessage, message))
//		{
//			StatusCode = HttpStatusCode.BadRequest;
//		}
//
//		public NetworkException(string message, HttpStatusCode statusCode): base(string.Format(defaultMessage, message))
//		{
//			StatusCode = statusCode;
//		}
//
//		public NetworkException(string message, Exception innerException, HttpStatusCode statusCode):base(string.Format(defaultMessage, message), innerException)
//		{
//			StatusCode = statusCode;
//		}
//
//		private static string getErrorMessage(WebException ex){
//
//		}
	}
}

