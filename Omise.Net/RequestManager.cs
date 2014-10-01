using System;
using System.Net;
using System.IO;
using System.Text;

namespace Omise
{
	public class RequestManager
	{
		private string apiUrlBase;
		private string apiKey;
		private string encodedCredentials;

		public RequestManager (string apiUrlBase, string apiKey)
		{
			this.apiUrlBase = apiUrlBase;
			this.apiKey = apiKey;
			this.encodedCredentials = Convert.ToBase64String (Encoding.GetEncoding ("ISO-8859-1").GetBytes (this.apiKey + ":"));
		}

		public static RequestManager Create (string apiUrlBase, string apiKey)
		{
			return new RequestManager (apiUrlBase, apiKey);
		}

		public string ExecuteRequest (string path, string method, string payload)
		{
			StringBuilder result = new StringBuilder ();
			path = path.StartsWith ("/") ? path : "/" + path;

			var request = WebRequest.Create (apiUrlBase + path);
			request.Headers.Add ("Authorization", "Basic " + this.encodedCredentials);
			request.Method = method;
			request.ContentType = "application/x-www-form-urlencoded";
			if (payload != null) {
				byte[] data = Encoding.UTF8.GetBytes (payload);
				try {
					using (Stream reqStream = request.GetRequestStream ()) {
						reqStream.Write (data, 0, data.Length);
					}
				} catch (WebException ex) {
					throw new ApiException (ex);
				} catch (Exception ex) {
					throw ex;
				}
			}

			try {
				using (WebResponse response = request.GetResponse ()) {
					using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
						string line;
						while ((line = reader.ReadLine ()) != null) {
							result.AppendLine (line);
						}
					}
				}

				return result.ToString ();
			} catch (WebException ex) {
				throw new ApiException (ex);
			} catch (Exception ex) {
				if (ex.Message.IndexOf ("Unauthorized") > -1) {
					throw new InvalidCredentialException ();
				} else {
					throw ex;
				}
			}
		}

		//		public string ExecutePutRequest (string payload, string path)
		//		{
		//			StringBuilder result = new StringBuilder ();
		//			path = path.StartsWith ("/") ? path : "/" + path;
		//			WebRequest req = PutRequest (apiUrlBase + path);
		//			byte[] data = Encoding.UTF8.GetBytes (payload);
		//			using (Stream reqStream = req.GetRequestStream ()) {
		//				reqStream.Write (data, 0, data.Length);
		//				using (WebResponse response = req.GetResponse ()) {
		//					using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
		//						string line;
		//						while ((line = reader.ReadLine ()) != null) {
		//							result.AppendLine (line);
		//						}
		//					}
		//				}
		//			}
		//
		//
		//			return result.ToString ();
		//		}
		//
		//		public string ExecutePatchRequest (string payload, string path)
		//		{
		//			StringBuilder result = new StringBuilder ();
		//			path = path.StartsWith ("/") ? path : "/" + path;
		//			WebRequest req = PutRequest (apiUrlBase + path);
		//			byte[] data = Encoding.UTF8.GetBytes (payload);
		//			using (Stream reqStream = req.GetRequestStream ()) {
		//				reqStream.Write (data, 0, data.Length);
		//				using (WebResponse response = req.GetResponse ()) {
		//					using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
		//						string line;
		//						while ((line = reader.ReadLine ()) != null) {
		//							result.AppendLine (line);
		//						}
		//					}
		//				}
		//			}
		//
		//
		//			return result.ToString ();
		//		}
		//
		//		public string ExecuteGetRequest (string path)
		//		{
		//			StringBuilder result = new StringBuilder ();
		//			path = path.StartsWith ("/") ? path : "/" + path;
		//			WebRequest req = GetRequest (apiUrlBase + path);
		//			using (Stream reqStream = req.GetRequestStream ()) {
		//				using (WebResponse response = req.GetResponse ()) {
		//					using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
		//						string line;
		//						while ((line = reader.ReadLine ()) != null) {
		//							result.AppendLine (line);
		//						}
		//					}
		//				}
		//			}
		//
		//			return result.ToString ();
		//		}
	}
}

