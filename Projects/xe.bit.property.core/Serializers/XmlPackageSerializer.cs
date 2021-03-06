﻿using System.IO;
using System.Text;
using System.Xml;
using xe.bit.property.core.Request.Interfaces;
using xe.bit.property.core.Serializers.Interfaces;
using xe.bit.property.core.Utility.Xml;

namespace xe.bit.property.core.Serializers
{
	public class XmlPackageSerializer : ISerializer
	{
		public void Serialize(Stream stream, IPackage package, bool isAddRequest)
		{
			using (var writer = XmlWriter.Create(stream))
			{
				Serialize(package, isAddRequest, writer);
			}
		}

		public string Serialize(IPackage package, bool isAddRequest)
		{
			using (var ms = new MemoryStream())
			using (var writer = XmlWriter.Create(ms, new XmlWriterSettings { Encoding = new UTF8Encoding(false)}))
			{
				Serialize(package, isAddRequest, writer);
				return new UTF8Encoding(false).GetString(ms.ToArray());
			}
		}

		public void Serialize(IPackage package, bool isAddRequest, string fileName)
		{
			using (var fs = new StreamWriter(fileName, false, new UTF8Encoding(false)))
			using (var writer = XmlWriter.Create(fs, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Fragment, OmitXmlDeclaration = true }))
			{
				Serialize(package, isAddRequest, writer);
			}
		}

		private void Serialize(IPackage package, bool isAddRequest, XmlWriter writer)
		{
			writer
				.StartDocument()
				.StartElement(isAddRequest ? "AddItemsRequest" : "RemoveItemsRequest", "http://www.xe.gr")
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