using System.IO;
using System.Xml;
using xe.bit.property.core.Request;
using xe.bit.property.core.Serializers.Interfaces;
using xe.bit.property.core.Utility.Xml;

namespace xe.bit.property.core.Serializers
{
	public class XmlPackageSerializer : ISerializer
	{
		public string Serialize(Package package, bool isAddRequest)
		{
			using (var ms = new MemoryStream())
			using (var writer = XmlWriter.Create(ms))
			{
				writer
					.StartDocument()
					.Element(isAddRequest ? "AddItemsRequest" : "RemoveItemsRequest")
					.Element("Package.xeAuthToken", package.XeAuthToken)
					.Element("Package.schemaVersion", package.SchemaVersion)
					.Element("Package.id", package.Id)
					.Element("Package.timestamp", package.Timestamp.ToString(("yyyy-MM-ddTHH\\:mm")))
					.Element("Package.trademark", package.Trademark)
					.Element("Package.skipAssets", package.SkipAssets)
					.Element("Package.policy", package.Policy);

				foreach (var ad in package.Ads)
				{
					var buffer = ad.Serialize().ToCharArray();
					writer.WriteRaw(buffer, 0, buffer.Length - 1);
				}

				writer.CloseElement();

				writer.Flush();
				writer.Close();

				return System.Text.Encoding.Default.GetString(ms.ToArray());
			}
		}
	}
}