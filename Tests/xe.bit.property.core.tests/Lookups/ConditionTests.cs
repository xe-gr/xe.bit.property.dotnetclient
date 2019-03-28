using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class ConditionTests : LookupTests
	{
		private static readonly string[] EnumValues = {"NEWBUILT", "UNDER_CONSTRUCTION", "UNFINISHED", "USED"};

		public ConditionTests()
		{
			Values = EnumValues;
			Type = typeof(Condition);
			Ignore = false;
		}
	}
}
