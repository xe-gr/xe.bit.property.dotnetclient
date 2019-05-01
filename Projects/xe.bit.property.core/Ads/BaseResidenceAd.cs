using System.Collections.Generic;

namespace xe.bit.property.core.Ads
{
	public class BaseResidenceAd : BaseAd
	{
		public virtual string RefId { get; set; }
		public virtual Geo Geo { get; } = new Geo();
		public virtual List<Asset> Assets { get; } = new List<Asset>();

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