using FluentValidation;
using xe.bit.property.core.Errors;
using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.Validators
{
	public class ResidenceAdHolidayValidator : ResidenceValidator
	{
		public ResidenceAdHolidayValidator()
		{
			RuleFor(ad => ad.AdType)
				.Equal(ItemType.re_residence_hol)
				.WithMessage(Messages.AddTypeMustBeResidenceHoliday);

			AddOtherRules();
		}
	}
}
