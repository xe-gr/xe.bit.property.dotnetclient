using FluentValidation;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Errors;
using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.Validators
{
	public class ParkingAdValidator : AbstractValidator<ParkingAd>
	{
		public ParkingAdValidator()
		{
			RuleFor(x => x.AdType)
				.Equal(ItemType.re_parking)
				.WithMessage(Messages.ItemTypeMustBeParking);

			RuleFor(x => x.Area.HasValue)
				.Equal(true)
				.WithMessage(Messages.ParkingAreaMustHaveValue);

			RuleFor(x => x.Level.HasValue)
				.Equal(true)
				.WithMessage(Messages.ParkingLevelMustHaveValue);
		}
	}
}