using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class ResidenceItemTypeTests : LookupTests
	{
		private static readonly string[] EnumValues = {"APARTMENT", "BUILDING", "HOUSE", "OIKEIA", "SPLIT_LEVEL"};

		public ResidenceItemTypeTests()
		{
			Values = EnumValues;
			Type = typeof(ResidenceHolItemType);
			Ignore = false;
		}
	}
}