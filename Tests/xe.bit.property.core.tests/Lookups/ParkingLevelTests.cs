using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class ParkingLevelTests : LookupWithFlagsTests
	{
		private static readonly string[] EnumValues = {"GROUND", "LEV_1", "LEV_2", "LEV_3", "LEV_4", "SUB_1", "SUB_2", "SUB_3", "SUB_4"};

		public ParkingLevelTests()
		{
			Values = EnumValues;
			Type = typeof(ParkingLevel);
			Ignore = false;
		}
	}
}