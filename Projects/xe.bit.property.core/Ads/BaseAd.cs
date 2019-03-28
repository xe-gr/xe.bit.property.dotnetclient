using xe.bit.property.core.Iso;
using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.Ads
{
	public class BaseAd
	{
		public virtual ItemType Type { get; set; }
		public virtual string RefId { get; set; }
		public virtual string OwnerId { get; set; }
		public virtual string MajorPhone { get; set; }
		public virtual string DepartmentOnCategory { get; protected set; } = "Real Estate";
		public virtual string[] OtherPhones { get; set; } = { };
		public virtual string InternetText { get; set; }
		public virtual string AddOnText { get; set; }
		public virtual string BodyText { get; set; }
		public virtual decimal Price { get; set; }
		public virtual CurrencyCode Currency { get; set; }
		public virtual TransactionFrequency Frequency { get; set; }
		public virtual TransactionType TransactionType { get; set; }
		public bool? IsOffer { get; set; }
		public bool? IsPromo { get; set; }
		public bool? IsNegotiable { get; set; }
	}
}