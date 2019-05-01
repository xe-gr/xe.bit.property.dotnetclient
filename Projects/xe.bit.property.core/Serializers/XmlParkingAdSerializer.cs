using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Utility.Xml;

namespace xe.bit.property.core.Serializers
{
	public class XmlParkingAdSerializer : XmlBaseSerializer
	{
		public override string Serialize(BaseAd ad)
		{
			using (var ms = new MemoryStream())
			using (var writer = XmlWriter.Create(ms, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Fragment, OmitXmlDeclaration = true, Encoding = new UTF8Encoding(false) }))
			{
				SerializeParking((ParkingAd)ad, writer);

				writer.CloseElement();

				writer.Flush();
				writer.Close();
				return new UTF8Encoding(false).GetString(ms.ToArray());
			}
		}

		public override string Serialize(BaseAd ad, bool skipAssets)
		{
			return Serialize(ad);
		}

		private void SerializeParking(ParkingAd ad, XmlWriter writer)
		{
			writer
				.ElementWithAttributes("Item", new Dictionary<string, string> { { "type", ad.AdType.ToString() }})
				.NewLine()
				.Field("Item.area", ad.Area)
				.Field("Item.usage", ad.Usage)
				.Field("Item.slots", ad.Slots)
				.Field("Item.level", ad.Level)
				.Field("Item.hasElectricDoor", ad.HasElectricDoor)
				.Field("Item.hasAlarm", ad.HasAlarm)
				.Field("Item.isAgentAccepted", ad.IsAgentAccepted);
		}
	}
}
