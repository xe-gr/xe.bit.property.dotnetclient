using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class EnergyClassTests : LookupTests
	{
		private static readonly string[] EnumValues =
		{
			"A",
			"A_PLUS",
			"B",
			"B_PLUS",
			"C",
			"D",
			"E",
			"Z",
			"H",
			"NOT_EFFICIENT",
			"NOT_APPLICABLE"
		};

		public EnergyClassTests()
		{
			Values = EnumValues;
			Type = typeof(EnergyClass);
			Ignore = false;
		}
	}
}
