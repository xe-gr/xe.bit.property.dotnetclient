using xe.bit.property.core.Ads;
using xe.bit.property.core.Errors;
using xe.bit.property.core.Validators;
using Xunit;

namespace xe.bit.property.core.tests.Validators
{
	public class GeoValidatorTests
	{
		[Theory]
		[InlineData(null, Messages.AreaIdCannotBeNullOrEmpty)]
		[InlineData("", Messages.AreaIdCannotBeNullOrEmpty)]
		[InlineData("invalid", Messages.AreaIdIsInvalid)]
		[InlineData("47", Messages.AreaIdIsException)]
		public void Validate(string areaId, string expectedMessage)
		{
			var geo = new Geo {AreaId = areaId};
			var validator = new GeoValidator();

			var result = validator.Validate(geo);

			Assert.Equal(1, result.Errors.Count);
			Assert.Equal(string.Format(expectedMessage, geo.AreaId), result.Errors[0].ErrorMessage);
		}

		[Fact]
		public void ValidationSuccessful()
		{
			var geo = new Geo { AreaId = "332-269" };
			var validator = new GeoValidator();

			var result = validator.Validate(geo);

			Assert.True(result.IsValid);
		}
	}
}
