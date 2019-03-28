using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.tests.Lookups
{
	public class TransactionTypeTests : LookupTests
	{
		private static readonly string[] EnumValues =
		{
			"SELL_NORMAL",
			"SELL_EXCHANGE",
			"SELL_AUCTION",
			"SELL_GIFT",
			"SELL_ANTIPAROXI",
			"BUY_NORMAL",
			"BUY_EXCHANGE",
			"BUY_GIFT",
			"BUY_ANTIPAROXI",
			"RENT_NORMAL",
			"LET_NORMAL"
		};

		public TransactionTypeTests()
		{
			Values = EnumValues;
			Type = typeof(TransactionType);
			Ignore = false;
		}
	}
}
