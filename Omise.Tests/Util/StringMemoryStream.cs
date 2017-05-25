using System.IO;
using System.Text;

namespace Omise.Tests.Util
{
    public class StringMemoryStream : MemoryStream
    {
        public StringMemoryStream() : base()
        {
        }

        public StringMemoryStream(string value)
            : base(Encoding.UTF8.GetBytes(value))
        {
        }

        public string ToDecodedString()
        {
            var buffer = ToArray();
            return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        }
    }
}

