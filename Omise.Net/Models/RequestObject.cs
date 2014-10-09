using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Omise
{
	public abstract class RequestObject : IValidatable
	{
		/// <summary>
		/// Gets or sets the Id.
		/// </summary>
		/// <value>Id</value>
		public string Id{ get; set;}
		public virtual bool Valid{ get; set; }
		public virtual Dictionary<string, string> Errors{ get; set; }
		//protected abstract void validate ();
        public abstract string ToRequestParams();
	}
}

