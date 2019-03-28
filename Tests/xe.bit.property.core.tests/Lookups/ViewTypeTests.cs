using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class ViewTypeTests : LookupWithFlagsTests
	{
		private static readonly string[] EnumValues = {"FOREST", "MOUNTAIN", "SEA", "UNLIMITED"};

		public ViewTypeTests()
		{
			Values = EnumValues;
			Type = typeof(ViewType);
			Ignore = false;
		}
	}
}