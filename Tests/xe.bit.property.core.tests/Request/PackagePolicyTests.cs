using xe.bit.property.core.Request;
using xe.bit.property.core.tests.Lookups;

namespace xe.bit.property.core.tests.Request
{
	public class PackagePolicyTests : LookupTests
	{
		private static readonly string[] EnumValues = {"RENEW_ALL_STOCK", "INCREMENTAL"};

		public PackagePolicyTests()
		{
			Values = EnumValues;
			Type = typeof(PackagePolicy);
			Ignore = false;
		}
	}
}
