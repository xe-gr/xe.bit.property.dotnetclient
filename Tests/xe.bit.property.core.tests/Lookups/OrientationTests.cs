using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class OrientationTests : LookupTests
	{
		private static readonly string[] EnumValues = { "DIAMPERES", "ESWTERIKO", "GONIAKO", "PROSOPSEOS" };

		public OrientationTests()
		{
			Values = EnumValues;
			Type = typeof(Orientation);
			Ignore = false;
		}
	}
}
