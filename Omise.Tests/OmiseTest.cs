using NUnit.Framework;

namespace Omise.Tests
{
	[TestFixture]
	public abstract class OmiseTest
	{
		protected static readonly Credentials DummyCredentials = new Credentials("pkey_test_123", "skey_test_123");
        protected static readonly Credentials RealCredentials = new Credentials(
            pkey: "pkey_test_55m9sc46dt7wequrp3j",
            skey: "skey_test_55m9sazu79b5ir95ced"
        );
	}
}