using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Validators;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Errors;
using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.Validators
{
	public class AssetsValidator : AbstractValidator<List<Asset>>
	{
		public AssetsValidator()
		{
			RuleForEach(assets => assets)
				.Must(asset => !string.IsNullOrEmpty(asset.Id)).WithMessage(Messages.AssetIdCannotBeNullOrEmpty)
				.Must(asset => !string.IsNullOrEmpty(asset.Uri)).WithMessage(Messages.AssetUriCannotBeNullOrEmpty);

			RuleFor(assets => assets.Count(x => x.Type == AssetType.IMAGE))
				.Must(count => count <= 10).WithMessage(Messages.TooManyImages);

			RuleFor(assets => assets.Count(x => x.Type == AssetType.VIDEO))
				.Must(count => count <= 1).WithMessage(Messages.TooManyVideos);

			RuleFor(assets => assets.Count(x => x.IsPrimary))
				.Must(count => count <= 1).WithMessage(Messages.MoreThanOnePrimaryAssets);
		}

		public void Validate(List<Asset> assets, CustomContext context)
		{
			var results = Validate(assets);
			if (!results.IsValid)
			{
				foreach (var error in results.Errors)
				{
					context.AddFailure(error);
				}
			}
		}
	}
}
