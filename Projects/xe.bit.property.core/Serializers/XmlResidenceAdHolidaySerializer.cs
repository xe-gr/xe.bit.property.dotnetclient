using System.Xml;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Utility.Xml;

namespace xe.bit.property.core.Serializers
{
	public class XmlResidenceAdHolidaySerializer : XmlResidenceAdSerializer
	{
		protected override void SerializeAdditional(BaseAd ad, XmlWriter writer)
		{
			var r = (ResidenceAdHoliday)ad;
			writer
				.Field("Item.activity", r.Activity)
				.Field("Item.utilities", r.Utilities)
				.Field("Item.proximityTo", r.ProximityTo);
		}
	}
}