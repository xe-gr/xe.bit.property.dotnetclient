using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class ResidenceItemSubtypeTests : LookupWithFlagsTests
	{
		private static readonly string[] EnumValues = {"FLOORFLAT", "LOFT", "PENTHOUSE", "SINGLEROOM"};

		public ResidenceItemSubtypeTests()
		{
			Values = EnumValues;
			Type = typeof(ResidenceItemSubtype);
			Ignore = false;
		}
	}
}