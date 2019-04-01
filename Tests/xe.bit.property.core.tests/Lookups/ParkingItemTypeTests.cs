using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class ParkingItemTypeTests : LookupTests
	{
		private static readonly string[] EnumValues = {"CLOSED", "OPEN", "YPOGEIO", "PILOTIS"};

		public ParkingItemTypeTests()
		{
			Values = EnumValues;
			Type = typeof(ParkingType);
			Ignore = false;
		}
	}
}