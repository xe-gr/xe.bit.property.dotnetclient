using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class UsageTests : LookupTests
	{
		private static readonly string[] EnumValues = {"BIKE", "BOAT", "CAR", "CARAVAN"};

		public UsageTests()
		{
			Values = EnumValues;
			Type = typeof(Usage);
			Ignore = false;
		}
	}
}
