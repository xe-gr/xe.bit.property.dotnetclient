using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class ConstructionTypeTests : LookupWithFlagsTests
	{
		private static readonly string[] EnumValues =
		{
			"LOFT",
			"LYOMENO",
			"NEOKLASIKO",
			"PRESERVED",
			"PROKAT",
			"ROCK",
			"STUDIO",
			"TRADITIONAL",
			"VILA"
		};

		public ConstructionTypeTests()
		{
			Values = EnumValues;
			Type = typeof(ConstructionType);
			Ignore = false;
		}
	}
}