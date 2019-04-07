using System;
using System.Collections.Generic;
using FluentValidation.Results;
using xe.bit.property.core.Iso;
using xe.bit.property.core.Lookups;
using xe.bit.property.core.Serializers.Interfaces;
using xe.bit.property.core.Utility;

namespace xe.bit.property.core.Ads
{
	public class BaseAd
	{
		public virtual ItemType AdType { get; protected set; }
		public virtual string RefId { get; set; }
		public virtual string OwnerId { get; set; }
		public virtual string MajorPhone { get; set; }
		public virtual string DepartmentOnCategory { get; set; } = "Real Estate";
		public virtual List<string> OtherPhones { get; protected set; } = new List<string>();
		public virtual string InternetText { get; set; }
		public virtual string AddOnText { get; set; }
		public virtual string BodyText { get; set; }
		public virtual decimal? Price { get; set; }
		public virtual CurrencyCode? Currency { get; set; }
		public virtual TransactionFrequency? Frequency { get; set; }
		public virtual TransactionType TransactionType { get; set; }
		public virtual bool? IsOffer { get; set; }
		public virtual bool? IsPromo { get; set; }
		public virtual bool? IsNegotiable { get; set; }
		public virtual Geo Geo { get; } = new Geo();
		public virtual List<Asset> Assets { get; } = new List<Asset>();
		public virtual IAddSerializer Serializer { get; }

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

		public virtual ValidationResult Validate()
		{
			return ValidationChain.ChainValidators(this);
		}

		public virtual string Serialize()
		{
			throw new NotImplementedException();
		}
	}
}