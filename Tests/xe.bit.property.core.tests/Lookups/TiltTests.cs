using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class TiltTests : LookupTests
	{
		private static readonly string[] EnumValues = {"AMFITHEATRIKO", "LEVEL", "TILTED"};

		public TiltTests()
		{
			Values = EnumValues;
			Type = typeof(Tilt);
			Ignore = false;
		}
	}
}
