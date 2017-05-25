using System.Net;
using Newtonsoft.Json;

namespace Omise
{
	public class ErrorResult
	{
		[JsonProperty("location")]
		public string Location { get; protected internal set; }

		[JsonIgnore]
		public HttpStatusCode HttpStatusCode { get; protected internal set; }

		[JsonProperty("code")]
		public string Code { get; protected internal set; }

        [JsonProperty("message")]
		public string Message { get; protected internal set; }
	}
}