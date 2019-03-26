using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class ProfItemTypeTests : LookupTests
	{
		private static readonly string[] EnumValues =
		{
			"ADVERTISING",
			"APARTMENT",
			"APOTHIKI",
			"BIOTEXNIA",
			"EXHIBITION",
			"FLOORAPARTMENT",
			"INDUSTRIAL",
			"KTIRIO",
			"OFFICE",
			"OIKIA",
			"PROF",
			"RETAIL",
			"ROOM",
			"STORAGE",
			"XVROS"
		};

		public ProfItemTypeTests()
		{
			Values = EnumValues;
			Type = typeof(ProfItemType);
			Ignore = false;
		}
	}
}