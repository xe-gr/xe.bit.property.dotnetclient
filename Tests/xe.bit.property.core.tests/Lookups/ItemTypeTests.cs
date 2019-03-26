using xe.bit.property.core.Lookups;
using xe.bit.property.core.tests.Helpers;
using Xunit;

namespace xe.bit.property.core.tests.Lookups
{
	public class ItemTypeTests
	{
		[Fact]
		public void EnumerateAndVerify()
		{
			LookupTestHelper.EnumerateAndVerify(typeof(ItemType), new []{ "re_land", "re_parking", "re_prof", "re_residence", "re_residence_hol" });
		}
	}
}
