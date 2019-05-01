using xe.bit.property.core.Ads;
using xe.bit.property.core.Errors;
using xe.bit.property.core.Lookups;
using xe.bit.property.core.Validators;
using Xunit;

namespace xe.bit.property.core.tests.Validators
{
	public class ParkingAdValidatorTests
	{
		[Fact]
		public void NoArea()
		{
			var ad = CreateAd();
			ad.Area = null;

			var validator = new ParkingAdValidator();
			var results = validator.Validate(ad);

			Assert.NotNull(results);
			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(Messages.ParkingAreaMustHaveValue, results.Errors[0].ErrorMessage);
		}

		[Fact]
		public void NoLevel()
		{
			var ad = CreateAd();
			ad.Level = null;

			var validator = new ParkingAdValidator();
			var results = validator.Validate(ad);

			Assert.NotNull(results);
			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(Messages.ParkingLevelMustHaveValue, results.Errors[0].ErrorMessage);
		}

		private ParkingAd CreateAd()
		{
			return new ParkingAd
			{
				Level = ParkingLevel.GROUND,
				Area = 20
			};
		}
	}
}
