using System;
using System.Collections.Generic;
using xe.bit.property.core.Ads;

namespace xe.bit.property.core.Request
{
	public class Package
	{
		public virtual string XeAuthToken { get; set; }
		public virtual string SchemaVersion { get; set; } = "1.1";
		public virtual string Id { get; set; }
		public virtual DateTime Timestamp { get; set; } = DateTime.UtcNow;
		public virtual string StoreId { get; set; }
		public virtual string Trademark { get; set; }
		public virtual bool? SkipAssets { get; set; }

		public virtual List<BaseAd> Ads { get; protected set; } = new List<BaseAd>();

		public void AddItem(BaseAd ad)
		{
			Ads.Add(ad);
		}

		public void ClearItems()
		{
			Ads.Clear();
		}
	}
}