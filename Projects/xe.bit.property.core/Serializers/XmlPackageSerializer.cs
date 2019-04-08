using System.IO;
using System.Text;
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
				Serialize(package, isAddRequest, writer);
				return Encoding.Default.GetString(ms.ToArray());
			}
		}

		public void Serialize(Package package, bool isAddRequest, string fileName)
		{
			using (var fs = new StreamWriter(fileName, false, Encoding.UTF8))
			using (var writer = XmlWriter.Create(fs))
			{
				Serialize(package, isAddRequest, writer);
			}
		}

		private void Serialize(Package package, bool isAddRequest, XmlWriter writer)
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
				var buffer = ad.Serialize(package.SkipAssets ?? false).ToCharArray();
				writer.WriteRaw(buffer, 0, buffer.Length - 1);
			}

			writer.CloseElement();

			writer.Flush();
			writer.Close();
		}
	}
}