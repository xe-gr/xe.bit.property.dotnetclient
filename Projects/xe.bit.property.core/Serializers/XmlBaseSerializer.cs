using System;
using System.Collections.Generic;
using System.Xml;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Lookups;
using xe.bit.property.core.Serializers.Interfaces;
using xe.bit.property.core.Utility.Xml;

namespace xe.bit.property.core.Serializers
{
	public class XmlBaseSerializer : IAddSerializer
	{
		public virtual string Serialize(BaseAd ad)
		{
			throw new NotImplementedException();
		}

		public virtual string Serialize(BaseAd ad, bool skipAssets)
		{
			throw new NotImplementedException();
		}

		public virtual void SerializeGeo(XmlWriter writer, BaseAd ad)
		{
			if (!(ad is BaseResidenceAd residenceAd))
			{
				return;
			}

			var geo = residenceAd.Geo;

			writer
				.Field("Geo.areaId", geo.AreaId)
				.Field("Geo.subAreaDescription", geo.SubAreaDescription)
				.Field("Geo.streetName", geo.StreetName)
				.Field("Geo.streetNumber", geo.StreetNumber)
				.Field("Geo.longitude", geo.Longitude, false)
				.Field("Geo.latitude", geo.Latitude, false)
				.Field("Geo.postcode", geo.PostCode);
		}

		public virtual void SerializeFinancial(XmlWriter writer, BaseAd ad)
		{
			writer
				.Element("Transaction.price", ad.Price)
				.Element("Transaction.currency", ad.Currency)
				.Element("Transaction.frequency", ad.Frequency)
				.Element("Transaction.type", ad.TransactionType)
				.Element("Transaction.isOffer", ad.IsOffer)
				.Element("Transaction.isPromo", ad.IsPromo)
				.Element("Transaction.isNegotiable", ad.IsNegotiable);
		}

		public virtual void SerializeAssets(XmlWriter writer, BaseAd ad)
		{
			if (!(ad is BaseResidenceAd residenceAd))
			{
				return;
			}

			foreach (var asset in residenceAd.Assets)
			{
				writer
					.Element("Asset")
					.Element("Asset.type", asset.Type)
					.Element("Asset.id", asset.Id)
					.Element("Asset.fileType", asset.FileType)
					.Element("Asset.status", asset.Status)
					.Element("Asset.isPrimary", asset.IsPrimary, true)
					.Element("Asset.caption", asset.Caption)
					.Element("Asset.order", asset.Order);

				if (asset.Type == AssetType.IMAGE)
				{
					writer.Element("Asset.uri", asset.Uri);
				}
				else
				{
					writer.CData("Asset.uri", asset.Uri);
				}

				foreach (var key in asset.Properties.Keys)
				{
					writer.ElementWithAttributes("Asset.properties", new Dictionary<string, string> {{"key", asset.Properties[key]}}, true);
				}

				writer.CloseElement();
			}
		}
	}
}
