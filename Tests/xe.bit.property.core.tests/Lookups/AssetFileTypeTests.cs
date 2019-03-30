using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class AssetFileTypeTests : LookupTests
	{
		private static readonly string[] EnumValues = {"JPEG"};

		public AssetFileTypeTests()
		{
			Values = EnumValues;
			Type = typeof(AssetFileType);
			Ignore = false;
		}
	}
}
