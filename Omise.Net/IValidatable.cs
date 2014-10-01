using System;
using System.Collections.Generic;

namespace Omise
{
	public interface IValidatable
	{
		Dictionary<string, string> Errors{ get; set; }
		bool Valid{ get; set; }
	}
}

