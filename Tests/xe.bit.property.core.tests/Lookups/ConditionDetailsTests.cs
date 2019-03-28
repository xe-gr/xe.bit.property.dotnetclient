using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class ConditionDetailsTests : LookupTests
	{
		private static readonly string[] EnumValues = {"GOOD", "NEEDS_REPAIR", "PERFECT", "REFURBISHED"};

		public ConditionDetailsTests()
		{
			Values = EnumValues;
			Type = typeof(ConditionDetails);
			Ignore = false;
		}
	}
}
