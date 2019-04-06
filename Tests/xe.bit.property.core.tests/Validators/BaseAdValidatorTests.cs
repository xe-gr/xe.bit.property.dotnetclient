using xe.bit.property.core.Ads;
using xe.bit.property.core.Errors;
using xe.bit.property.core.Validators;
using Xunit;

namespace xe.bit.property.core.tests.Validators
{
	public class BaseAdValidatorTests
	{
		[Theory]
		[InlineData(FieldToVerify.OwnerId, null, Messages.OwnerIdCannotBeNullOrEmpty)]
		[InlineData(FieldToVerify.OwnerId, "", Messages.OwnerIdCannotBeNullOrEmpty)]
		[InlineData(FieldToVerify.MajorPhone, null, Messages.MajorPhoneCannotBeNullOrEmpty)]
		[InlineData(FieldToVerify.MajorPhone, "", Messages.MajorPhoneCannotBeNullOrEmpty)]
		[InlineData(FieldToVerify.RefId, null, Messages.RefIdCannotBeNullOrEmpty)]
		[InlineData(FieldToVerify.RefId, "", Messages.RefIdCannotBeNullOrEmpty)]
		public void VerifyField(FieldToVerify field, string value, string expected)
		{
			var ad = CreateAd();
			SetValue(ad, value, field);

			var validator = new BaseAdValidator();

			var results = validator.Validate(ad);

			Assert.False(results.IsValid);
			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(expected, results.Errors[0].ErrorMessage);
		}

		private BaseAd CreateAd()
		{
			return new BaseAd
			{
				RefId = "ref id",
				OwnerId = "owner id",
				MajorPhone = "major phone"
			};
		}

		private void SetValue(BaseAd ad, string fieldValue, FieldToVerify field)
		{
			switch (field)
			{
				case FieldToVerify.MajorPhone:
					ad.MajorPhone = fieldValue;
					break;
				case FieldToVerify.OwnerId:
					ad.OwnerId = fieldValue;
					break;
				case FieldToVerify.RefId:
					ad.RefId = fieldValue;
					break;
			}
		}

		public enum FieldToVerify
		{
			OwnerId,
			RefId,
			MajorPhone
		}
	}
}
