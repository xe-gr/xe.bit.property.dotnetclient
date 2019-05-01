using FluentValidation;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Errors;

namespace xe.bit.property.core.Validators
{
	public class BaseResidenceAdValidator : AbstractValidator<BaseResidenceAd>
	{
		public BaseResidenceAdValidator()
		{
			RuleFor(ad => ad.RefId)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotNull().WithMessage(Messages.RefIdCannotBeNullOrEmpty)
				.NotEmpty().WithMessage(Messages.RefIdCannotBeNullOrEmpty);

			RuleFor(ad => ad.OwnerId)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotNull().WithMessage(Messages.OwnerIdCannotBeNullOrEmpty)
				.NotEmpty().WithMessage(Messages.OwnerIdCannotBeNullOrEmpty);

			RuleFor(ad => ad.MajorPhone)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotNull().WithMessage(Messages.MajorPhoneCannotBeNullOrEmpty)
				.NotEmpty().WithMessage(Messages.MajorPhoneCannotBeNullOrEmpty);
		}
	}
}