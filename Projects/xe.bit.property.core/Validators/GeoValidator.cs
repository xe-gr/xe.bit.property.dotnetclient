using FluentValidation;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Errors;
using xe.bit.property.core.Utility;

namespace xe.bit.property.core.Validators
{
	public class GeoValidator : AbstractValidator<Geo>
	{
		public GeoValidator()
		{
			When(geo => string.IsNullOrEmpty(geo.AreaId), () =>
					{
						RuleFor(geo => geo.AreaId)
							.Custom((s, context) => context.AddFailure(Messages.AreaIdCannotBeNullOrEmpty));
					})
				.Otherwise(() =>
				{
					RuleFor(geo => AreaInfo.IsAreaIdValid(geo.AreaId))
						.Equal(true)
						.WithMessage(geo => string.Format(Messages.AreaIdIsInvalid, geo.AreaId));

					RuleFor(geo => AreaInfo.IsAreaIdException(geo.AreaId))
						.Equal(false)
						.WithMessage(geo => string.Format(Messages.AreaIdIsException, geo.AreaId));
				});
		}
	}
}