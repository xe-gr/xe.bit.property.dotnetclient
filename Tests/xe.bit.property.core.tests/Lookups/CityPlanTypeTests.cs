using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class CityPlanTypeTests : LookupTests
	{
		private static readonly string[] EnumValues = { "IN", "OUT", "TOBE" };

		public CityPlanTypeTests()
		{
			Values = EnumValues;
			Type = typeof(CityPlanType);
			Ignore = false;
		}
	}
}
