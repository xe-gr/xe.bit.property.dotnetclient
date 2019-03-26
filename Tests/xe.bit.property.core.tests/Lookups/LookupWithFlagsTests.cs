using xe.bit.property.core.tests.Helpers;
using Xunit;

namespace xe.bit.property.core.tests.Lookups
{
	public class LookupWithFlagsTests : LookupTests
	{

		[Fact]
		public virtual void VerifyFlags()
		{
			if (Ignore) return;
			LookupTestHelper.VerifyFlags(Type, Values);
		}
	}
}