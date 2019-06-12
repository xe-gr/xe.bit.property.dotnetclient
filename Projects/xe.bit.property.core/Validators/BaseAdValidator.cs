using FluentValidation;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Errors;

namespace xe.bit.property.core.Validators
{
	public class BaseAdValidator : AbstractValidator<BaseAd>
	{
		public BaseAdValidator()
		{
			RuleFor(ad => ad.OwnerId)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotNull().WithMessage(Messages.OwnerIdCannotBeNullOrEmpty)
				.NotEmpty().WithMessage(Messages.OwnerIdCannotBeNullOrEmpty);

			RuleFor(ad => ad.MajorPhone)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotNull().WithMessage(Messages.MajorPhoneCannotBeNullOrEmpty)
				.NotEmpty().WithMessage(Messages.MajorPhoneCannotBeNullOrEmpty);

            RuleFor(ad => ad.Price)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage(Messages.PriceCannotBeNullOrEmpty)
                .NotEmpty().WithMessage(Messages.PriceCannotBeNullOrEmpty);
        }
	}
}