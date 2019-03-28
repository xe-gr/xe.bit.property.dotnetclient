using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class AssetStatusTests : LookupTests
	{
		private static readonly string[] EnumValues = {"ACTIVE", "INACTIVE"};

		public AssetStatusTests()
		{
			Values = EnumValues;
			Type = typeof(AssetStatus);
			Ignore = false;
		}
	}
}
