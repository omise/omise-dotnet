using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise
{
	public abstract class RequestObject : IValidatable
	{
		public string Id{ get; set;}
		public virtual DateTime CreatedAt{ get; set;}
		public virtual DateTime UpdatedAt{ get; set;}
		public virtual bool Valid{ get; set; }
		public virtual Dictionary<string, string> Errors{ get; set; }
		protected abstract void validate ();

		public virtual string ToRequestParams(){
			return this.ToString ();
		}
	}
}

