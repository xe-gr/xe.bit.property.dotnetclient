using System;
using System.Xml;
using xe.bit.property.core.Ads;
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

		public virtual void SerializeGeo(XmlWriter writer, BaseAd ad)
		{
			writer
				.Field("Geo.areaId", ad.Geo.AreaId)
				.Field("Geo.subAreaDescription", ad.Geo.SubAreaDescription)
				.Field("Geo.streetName", ad.Geo.StreetName)
				.Field("Geo.streetNumber", ad.Geo.StreetNumber)
				.Field("Geo.longitude", ad.Geo.Longitude, false)
				.Field("Geo.latitude", ad.Geo.Latitude, false)
				.Field("Geo.postcode", ad.Geo.PostCode);
		}

		public virtual void SerializeFinancial(XmlWriter writer, BaseAd ad)
		{
			writer
				.Field("Transaction.price", ad.Price)
				.Field("Transaction.currency", ad.Currency)
				.Field("Transaction.frequency", ad.Frequency)
				.Field("Transaction.type", ad.TransactionType)
				.Field("Transaction.isOffer", ad.IsOffer)
				.Field("Transaction.isPromo", ad.IsPromo)
				.Field("Transaction.isNegotiable", ad.IsNegotiable);
		}
	}
}
