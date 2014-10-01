using System;

namespace Omise
{
	public class DateTimeHelper
	{
		private static readonly string DateTimeFormat = "dd/MM/yyyy HH:mm:ss";
		public DateTimeHelper ()
		{
		}

		public static string ToApiDateString(DateTime datetime){
			return datetime.ToString(DateTimeFormat);
		}
	}
}

