using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class TransactionFrequencyTests : LookupTests
	{
		private static readonly string[] EnumValues = {"ANNUALY", "DAILY", "HOURLY", "MONTHLY", "ONCE", "QUARTERLY", "WEEKLY"};

		public TransactionFrequencyTests()
		{
			Values = EnumValues;
			Type = typeof(TransactionFrequency);
			Ignore = false;
		}
	}
}
