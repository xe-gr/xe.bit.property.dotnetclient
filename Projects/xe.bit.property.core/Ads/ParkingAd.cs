using FluentValidation.Results;
using xe.bit.property.core.Lookups;
using xe.bit.property.core.Serializers;
using xe.bit.property.core.Serializers.Interfaces;
using xe.bit.property.core.Validators;

namespace xe.bit.property.core.Ads
{
	public class ParkingAd : BaseAd
	{
		public override ItemType AdType { get; protected set; } = ItemType.re_parking;
		public virtual decimal? Area { get; set; }
		public virtual Usage? Usage { get; set; }
		public virtual int? Slots { get; set; }
		public virtual ParkingLevel? Level { get; set; }
		public virtual bool? HasElectricDoor { get; set; }
		public virtual bool? HasAlarm { get; set; }
		public virtual bool? IsAgentAccepted { get; set; }
		public override IAddSerializer Serializer { get; } = new XmlParkingAdSerializer();

		public override ValidationResult Validate()
		{
			return new ParkingAdValidator().Validate(this);
		}

		public override string Serialize()
		{
			return Serializer.Serialize(this);
		}

		public override string Serialize(bool skipAssets)
		{
			return Serializer.Serialize(this);
		}
	}
}