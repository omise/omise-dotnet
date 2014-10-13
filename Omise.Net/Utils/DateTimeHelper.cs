using System;

namespace Omise
{
    /// <summary>
    /// Defines helper methods for converting datetime to other types
    /// </summary>
    public class DateTimeHelper
    {
        private static readonly string DateTimeFormat = "dd/MM/yyyy HH:mm:ss";
        /// <summary>
        /// Initialize the helper
        /// </summary>
        public DateTimeHelper()
        {
        }

        /// <summary>
        /// Convert datetime object to datetime string which can be passed to the api
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToApiDateString(DateTime datetime)
        {
            return datetime.ToString(DateTimeFormat);
        }
    }
}

