using System.ComponentModel;

namespace xe.bit.property.core.Lookups
{
	public enum TransactionType
	{
		[Description("SELL.NORMAL")]
		SELL_NORMAL,
		[Description("SELL.EXCHANGE")]
		SELL_EXCHANGE,
		[Description("SELL.AUCTION")]
		SELL_AUCTION,
		[Description("SELL.GIFT")]
		SELL_GIFT,
		[Description("SELL.ANTIPAROXI")]
		SELL_ANTIPAROXI,
		[Description("BUY.NORMAL")]
		BUY_NORMAL,
		[Description("BUY.EXCHANGE")]
		BUY_EXCHANGE,
		[Description("BUY.GIFT")]
		BUY_GIFT,
		[Description("BUY.ANTIPAROXI")]
		BUY_ANTIPAROXI,
		[Description("RENT.NORMAL")]
		RENT_NORMAL,
		[Description("LET.NORMAL")]
		LET_NORMAL
	}
}