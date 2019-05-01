using FluentValidation.Results;
using xe.bit.property.core.Lookups;
using xe.bit.property.core.Serializers;
using xe.bit.property.core.Serializers.Interfaces;
using xe.bit.property.core.Utility;
using xe.bit.property.core.Validators;

namespace xe.bit.property.core.Ads
{
	public class ResidenceAd : BaseResidenceAd
	{
		public override ItemType AdType { get; protected set; } = Lookups.ItemType.re_residence;
		public virtual ResidenceItemType ItemType { get; set; }
		public virtual ResidenceItemSubtype? SubType { get; set; }
		public virtual decimal? Area { get; set; }
		public virtual ProfLevel? Level { get; set; }
		public virtual ConstructionType? ConstructionType { get; set; }
		public virtual Condition? Condition { get; set; }
		public virtual ConditionDetails? ConditionDetails { get; set; }
		public virtual int ConstructionYear { get; set; }
		public virtual int? RefurbishmentYear { get; set; }
		public virtual int? Floors { get; set; }
		public virtual decimal? FloorsArea { get; set; }
		public virtual Orientation? Orientation { get; set; }
		public virtual int? Bedrooms { get; set; }
		public virtual int? MasterBedrooms { get; set; }
		public virtual int? Bathrooms { get; set; }
		public virtual int? Wc { get; set; }
		public virtual bool? HasParking { get; set; }
		public virtual ParkingType? ParkingType { get; set; }
		public virtual bool? HasStorage { get; set; }
		public virtual decimal? StorageArea { get; set; }
		public virtual bool? HasAutonomousHeating { get; set; }
		public virtual bool? HasCentralHeating { get; set; }
		public virtual bool? HasAirConditioning { get; set; }
		public virtual bool? HasSecureDoor { get; set; }
		public virtual ViewType? ViewType { get; set; }
		public virtual bool? HasFirePlace { get; set; }
		public virtual bool? HasSolarBoiler { get; set; }
		public virtual bool? WithoutElevator { get; set; }
		public virtual bool? HasNaturalGas { get; set; }
		public virtual bool? HasGarden { get; set; }
		public virtual decimal? GardenArea { get; set; }
		public virtual string Location { get; set; }
		public virtual decimal? Land { get; set; }
		public virtual AvailabilityType? AvailabilityType { get; set; }
		public virtual bool? HasTerraceArea { get; set; }
		public virtual decimal? TerraceArea { get; set; }
		public virtual bool? HasPool { get; set; }
		public virtual bool? HasTents { get; set; }
		public virtual bool? IsWithoutCommunalCharge { get; set; }
		public virtual bool? IsSuitableForProfessionalUse { get; set; }
		public virtual bool? IsFurnished { get; set; }
		public virtual string AvailableFrom { get; set; }
		public virtual string SpacesPlan { get; set; }
		public virtual bool? IsSuitableForStudents { get; set; }
		public virtual bool? IsAgentAccepted { get; set; }
		public virtual bool? HasSemiOpenSpaces { get; set; }
		public virtual decimal? SemiOpenSpacesArea { get; set; }
		public virtual EnergyClass? EnergyClass { get; set; }
		public override IAddSerializer Serializer { get; } = new XmlResidenceAdSerializer();

		public override ValidationResult Validate()
		{
			return ValidationChain.ChainValidators(this, new ResidenceAdValidator().Validate(this));
		}

		public override string Serialize(bool skipAssets)
		{
			return Serializer.Serialize(this, skipAssets);
		}
	}
}
