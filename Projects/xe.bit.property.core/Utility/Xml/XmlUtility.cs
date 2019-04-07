using System.Collections.Generic;
using System.Xml;

namespace xe.bit.property.core.Utility.Xml
{
	public static class XmlUtility
	{
		public static XmlWriter ElementWithAttributes(this XmlWriter writer, string element,
			Dictionary<string, string> attributes, bool end = false)
		{
			writer.WriteStartElement(element);
			foreach (var key in attributes.Keys)
			{
				writer.WriteAttributeString(key, attributes[key]);
			}

			if (end)
			{
				writer.WriteEndElement();
				writer.NewLine();
			}

			return writer;
		}

		public static XmlWriter Element(this XmlWriter writer, string element, string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return writer;
			}

			writer.WriteElementString(element, value);
			writer.NewLine();

			return writer;
		}

		public static XmlWriter Element(this XmlWriter writer, string element, bool? value)
		{
			if (!value.HasValue)
			{
				return writer;
			}

			writer.WriteElementString(element, value.ToString());
			writer.NewLine();

			return writer;
		}

		public static XmlWriter Element(this XmlWriter writer, string element)
		{
			writer.WriteStartElement(element);
			writer.NewLine();

			return writer;
		}

		public static XmlWriter CloseElement(this XmlWriter writer)
		{
			writer.WriteEndElement();
			writer.NewLine();

			return writer;
		}

		public static XmlWriter StartDocument(this XmlWriter writer)
		{
			writer.WriteStartDocument();
			writer.NewLine();

			return writer;
		}

		public static XmlWriter Element(this XmlWriter writer, string element, List<string> values,
			string valueElements)
		{
			if (values == null || values.Count == 0)
			{
				return writer;
			}

			writer.WriteStartElement(element);
			writer.NewLine();
			foreach (var value in values)
			{
				writer.Element(valueElements, value);
				writer.NewLine();
			}
			writer.WriteEndElement();
			writer.NewLine();

			return writer;
		}

		public static XmlWriter CData(this XmlWriter writer, string element, string data)
		{
			if (string.IsNullOrEmpty(data))
			{
				return writer;
			}

			writer.WriteStartElement(element);
			writer.NewLine();
			writer.WriteCData(data);
			writer.NewLine();
			writer.WriteEndElement();
			writer.NewLine();

			return writer;
		}

		public static XmlWriter Field(this XmlWriter writer, string name, string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return writer;
			}

			writer.WriteStartElement("Field");
			writer.NewLine();
			writer.Element("Name", name);
			writer.Element("Value", value);
			writer.WriteEndElement();
			writer.NewLine();

			return writer;
		}

		public static XmlWriter NewLine(this XmlWriter writer)
		{
			writer.WriteRaw(new[] { '\r', '\n' }, 0, 2);

			return writer;
		}
	}
}
