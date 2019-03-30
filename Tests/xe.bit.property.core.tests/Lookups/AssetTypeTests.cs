using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class AssetTypeTests : LookupTests
	{
		private static readonly string[] EnumValues = {"IMAGE", "VIDEO"};

		public AssetTypeTests()
		{
			Values = EnumValues;
			Type = typeof(AssetType);
			Ignore = false;
		}
	}
}
