using xe.bit.property.core.Ads;

namespace xe.bit.property.core.Serializers.Interfaces
{
	public interface IAddSerializer
	{
		string Serialize(BaseAd ad);
		string Serialize(BaseAd ad, bool skipAssets);
	}
}