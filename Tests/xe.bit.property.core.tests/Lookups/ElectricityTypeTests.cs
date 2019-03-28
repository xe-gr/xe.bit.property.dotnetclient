using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class ElectricityTypeTests : LookupTests
	{
		private static readonly string[] EnumValues = { "INDUSTRIAL", "SINGLE_PHASED", "TRI_PHASED" };

		public ElectricityTypeTests()
		{
			Values = EnumValues;
			Type = typeof(ElectricityType);
			Ignore = false;
		}
	}
}
