using System.Linq;
using FluentValidation.Results;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Validators;

namespace xe.bit.property.core.Utility
{
	public class ValidationChain
	{
		public static ValidationResult ChainValidators(BaseAd ad, ValidationResult results)
		{
			return new ValidationResult(results.Errors
				.Union(ChainValidators(ad).Errors));
		}

		public static ValidationResult ChainValidators(BaseAd ad)
		{
			var baseResults = new BaseAdValidator().Validate(ad);
			var geoResults = new GeoValidator().Validate(ad.Geo);
			var assetsValidator = new AssetsValidator().Validate(ad.Assets);

			return new ValidationResult(baseResults.Errors
				.Union(geoResults.Errors)
				.Union(assetsValidator.Errors));
		}
	}
}