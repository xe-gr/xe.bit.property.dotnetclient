using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class AvailabilityTypeTests : LookupTests
	{
		private static readonly string[] EnumValues = { "AVAILABLE", "OCCUPATED"};

		public AvailabilityTypeTests()
		{
			Values = EnumValues;
			Type = typeof(AvailabilityType);
			Ignore = false;
		}
	}
}
