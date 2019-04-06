using xe.bit.property.core.Errors;
using xe.bit.property.core.Request;
using xe.bit.property.core.Validators;
using Xunit;

namespace xe.bit.property.core.tests.Validators
{
	public class PackageValidatorTests
	{
		[Theory]
		[InlineData(FieldToVerify.PackageId, null, Messages.PackageIdCannotBeNullOrEmpty)]
		[InlineData(FieldToVerify.PackageId, "", Messages.PackageIdCannotBeNullOrEmpty)]
		[InlineData(FieldToVerify.SchemaVersion, null, Messages.SchemaVersionCannotBeNullOrEmpty)]
		[InlineData(FieldToVerify.SchemaVersion, "", Messages.SchemaVersionCannotBeNullOrEmpty)]
		[InlineData(FieldToVerify.XeAuthToken, null, Messages.AuthTokenCannotBeNullOrEmpty)]
		[InlineData(FieldToVerify.XeAuthToken, "", Messages.AuthTokenCannotBeNullOrEmpty)]
		public void VerifyRefId(FieldToVerify field, string value, string expected)
		{
			var p = CreatePackage();
			SetValue(p, value, field);

			var validator = new PackageValidator();

			var results = validator.Validate(p);

			Assert.False(results.IsValid);
			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(expected, results.Errors[0].ErrorMessage);
		}

		private Package CreatePackage()
		{
			return new Package
			{
				Id = "id",
				SchemaVersion = "version",
				XeAuthToken = "auth token"
			};
		}

		private void SetValue(Package p, string fieldValue, FieldToVerify field)
		{
			switch (field)
			{
				case FieldToVerify.PackageId:
					p.Id = fieldValue;
					break;
				case FieldToVerify.SchemaVersion:
					p.SchemaVersion = fieldValue;
					break;
				case FieldToVerify.XeAuthToken:
					p.XeAuthToken = fieldValue;
					break;
			}
		}

		public enum FieldToVerify
		{
			XeAuthToken,
			SchemaVersion,
			PackageId
		}
	}
}
