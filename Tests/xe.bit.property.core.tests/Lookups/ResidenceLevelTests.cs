using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class ResidenceLevelTests : LookupWithFlagsTests
	{
		private static readonly string[] EnumValues =
		{
			"L0",
			"L1",
			"L2",
			"L3",
			"L4",
			"L5",
			"L6",
			"L7",
			"L8",
			"LH",
			"LHH",
			"S1",
			"SH"
		};

		public ResidenceLevelTests()
		{
			Values = EnumValues;
			Type = typeof(ResidenceLevel);
			Ignore = false;
		}
	}
}