using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
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

		public static XmlWriter Element(this XmlWriter writer, string element, object value)
		{
			if (value == null)
			{
				return writer;
			}

			writer.WriteElementString(element, FindDescription(value));
			writer.NewLine();

			return writer;
		}

		public static XmlWriter Element(this XmlWriter writer, string element, bool? value, bool zeroOne = false)
		{
			if (!value.HasValue)
			{
				return writer;
			}

			writer.WriteElementString(element, zeroOne ? (value.Value ? "1" : "0") : value.ToString());
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

		public static XmlWriter Field(this XmlWriter writer, string name, decimal value)
		{
			return writer.Field(name, value.ToString(CultureInfo.GetCultureInfo("el")));
		}

		public static XmlWriter Field(this XmlWriter writer, string name, decimal? value, bool greekCulture = true)
		{
			return writer.Field(name, greekCulture ? value?.ToString(CultureInfo.GetCultureInfo("el")) : value?.ToString(CultureInfo.InvariantCulture));
		}

		public static XmlWriter Field(this XmlWriter writer, string name, bool? value, bool zeroOne = false)
		{
			return writer.Field(name, value.HasValue ? zeroOne ? value.Value ? "1" : "0" : value.ToString() : null);
		}

		public static XmlWriter Field(this XmlWriter writer, string name, object value)
		{
			if (value == null)
			{
				return writer;
			}

			return writer.Field(name, FindDescription(value));
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
			return writer.Raw("\r\n");
		}

		public static XmlWriter Raw(this XmlWriter writer, string raw)
		{
			var chars = raw.ToCharArray();
			writer.WriteRaw(chars, 0, chars.Length-1);

			return writer;
		}

		private static string FindDescription(object value)
		{
			var property = value.GetType();
			var field = property.GetField(value.ToString());
			if (field != null
			    && field.CustomAttributes != null
			    && field.CustomAttributes.Count() == 1
			    && field.CustomAttributes.First().AttributeType == typeof(DescriptionAttribute))
			{
				return field.CustomAttributes.First().ConstructorArguments[0].Value.ToString();
			}

			return value.ToString();
		}
	}
}
