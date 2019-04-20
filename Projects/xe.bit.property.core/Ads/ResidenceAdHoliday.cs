using FluentValidation.Results;
using xe.bit.property.core.Lookups;
using xe.bit.property.core.Serializers;
using xe.bit.property.core.Serializers.Interfaces;
using xe.bit.property.core.Utility;
using xe.bit.property.core.Validators;

namespace xe.bit.property.core.Ads
{
	public class ResidenceAdHoliday : ResidenceAd
	{
		public override ItemType AdType { get; protected set; } = Lookups.ItemType.re_residence_hol;
		public virtual string Activity { get; set; }
		public virtual string Utilities { get; set; }
		public virtual string ProximityTo { get; set; }

		public override IAddSerializer Serializer { get; } = new XmlResidenceAdHolidaySerializer();

		public override ValidationResult Validate()
		{
			return ValidationChain.ChainValidators(this, new ResidenceAdHolidayValidator().Validate(this));
		}

		public override string Serialize(bool skipAssets)
		{
			return Serializer.Serialize(this, skipAssets);
		}
	}
}
