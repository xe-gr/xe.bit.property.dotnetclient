using FluentValidation;
using xe.bit.property.core.Errors;
using xe.bit.property.core.Request;

namespace xe.bit.property.core.Validators
{
	public class PackageValidator : AbstractValidator<Package>
	{
		public PackageValidator()
		{
			RuleFor(p => p.XeAuthToken)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotNull().WithMessage(Messages.AuthTokenCannotBeNullOrEmpty)
				.NotEmpty().WithMessage(Messages.AuthTokenCannotBeNullOrEmpty);

			RuleFor(p => p.SchemaVersion)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotNull().WithMessage(Messages.SchemaVersionCannotBeNullOrEmpty)
				.NotEmpty().WithMessage(Messages.SchemaVersionCannotBeNullOrEmpty);

			RuleFor(p => p.Id)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotNull().WithMessage(Messages.PackageIdCannotBeNullOrEmpty)
				.NotEmpty().WithMessage(Messages.PackageIdCannotBeNullOrEmpty);
		}
	}
}