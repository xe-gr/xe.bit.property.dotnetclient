using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class LandItemTypeTests : LookupWithFlagsTests
	{
		private static readonly string[] EnumValues = {"AGROTEMAXIO", "EKTASH", "OIKOPEDO"};

		public LandItemTypeTests()
		{
			Values = EnumValues;
			Type = typeof(LandItemType);
			Ignore = false;
		}
	}
}