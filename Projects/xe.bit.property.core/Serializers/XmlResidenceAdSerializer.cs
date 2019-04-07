using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Serializers.Interfaces;
using xe.bit.property.core.Utility.Xml;

namespace xe.bit.property.core.Serializers
{
	public class XmlResidenceAdSerializer : IAddSerializer
	{
		public string Serialize(BaseAd ad)
		{
			using (var ms = new MemoryStream())
			using (var writer = XmlWriter.Create(ms, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Fragment, OmitXmlDeclaration = true }))
			{
				var r = (ResidenceAd)ad;

				writer
					.ElementWithAttributes("Item",
						new Dictionary<string, string> { { "type", ad.AdType.ToString() }, { "refId", ad.RefId } })
					.Element("Item.ownerId", ad.OwnerId)
					.Element("Item.majorPhone", ad.MajorPhone)
					.Element("Item.departmentOnCategory", ad.DepartmentOnCategory)
					.Element("Item.otherPhones", ad.OtherPhones, "Item.phone")
					.CData("Item.internetText", ad.InternetText)
					.CData("Item.addOnText", ad.AddOnText)
					.CData("Item.bodyText", ad.BodyText)
					.Field("Item.type", r.ItemType.ToString())
					.Field("Item.subtype", r.SubType?.ToString())
					.Field("Item.area", r.Area?.ToString(CultureInfo.GetCultureInfo("el")))
					.CloseElement();

				writer.Flush();
				writer.Close();
				return System.Text.Encoding.Default.GetString(ms.ToArray());
			}
		}
	}
}