using System.Collections.Generic;
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
		public virtual List<string> OtherPhones { get; protected set; } = new List<string>();
		public virtual string InternetText { get; set; }
		public virtual string AddOnText { get; set; }
		public virtual string BodyText { get; set; }
		public virtual decimal Price { get; set; }
		public virtual CurrencyCode Currency { get; set; }
		public virtual TransactionFrequency Frequency { get; set; }
		public virtual TransactionType TransactionType { get; set; }
		public virtual bool? IsOffer { get; set; }
		public virtual bool? IsPromo { get; set; }
		public virtual bool? IsNegotiable { get; set; }
		public virtual Geo Geo { get; protected set; } = new Geo();
		public virtual List<Asset> Assets { get; protected set; } = new List<Asset>();

		public void AddOtherPhone(string otherPhone)
		{
			OtherPhones.Add(otherPhone);
		}

		public void ClearOtherPhones()
		{
			OtherPhones.Clear();
		}

		public void AddAsset(Asset asset)
		{
			Assets.Add(asset);
		}

		public void ClearAssets()
		{
			Assets.Clear();
		}
	}
}