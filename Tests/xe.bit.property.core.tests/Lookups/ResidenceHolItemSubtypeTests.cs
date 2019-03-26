using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class ResidenceHolItemSubtypeTests : LookupWithFlagsTests
	{
		private static readonly string[] EnumValues = {"FLOORFLAT", "LOFT", "PENTHOUSE", "SINGLEROOM"};

		public ResidenceHolItemSubtypeTests()
		{
			Values = EnumValues;
			Type = typeof(ResidenceHolItemSubtype);
			Ignore = false;
		}
	}
}