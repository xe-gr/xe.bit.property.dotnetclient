using System.Collections.Generic;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Errors;
using xe.bit.property.core.Lookups;
using xe.bit.property.core.Validators;
using Xunit;

namespace xe.bit.property.core.tests.Validators
{
	public class AssetsValidatorTests
	{
		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void ValidateAssetId(string assetId)
		{
			var asset = CreateAsset(true);
			asset.Id = assetId;

			var validator = new AssetsValidator();

			var results = validator.Validate(new List<Asset> {asset});

			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(Messages.AssetIdCannotBeNullOrEmpty, results.Errors[0].ErrorMessage);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void ValidateAssetUri(string uri)
		{
			var asset = CreateAsset(true);
			asset.Uri = uri;

			var validator = new AssetsValidator();

			var results = validator.Validate(new List<Asset> { asset });

			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(Messages.AssetUriCannotBeNullOrEmpty, results.Errors[0].ErrorMessage);
		}

		[Fact]
		public void ValidateNumberOfVideos()
		{
			var list = new List<Asset> {CreateAsset(true), CreateAsset(false)};
			foreach (var item in list)
			{
				item.Type = AssetType.VIDEO;
			}

			var validator = new AssetsValidator();

			var results = validator.Validate(list);

			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(Messages.TooManyVideos, results.Errors[0].ErrorMessage);
		}

		[Fact]
		public void ValidateNumberOfImages()
		{
			var list = new List<Asset>();
			for (var i = 1; i <= 11; i++)
			{
				list.Add(CreateAsset(i == 1));
			}

			var validator = new AssetsValidator();

			var results = validator.Validate(list);

			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(Messages.TooManyImages, results.Errors[0].ErrorMessage);
		}

		[Fact]
		public void ValidateOnlyOnePrimary()
		{
			var list = new List<Asset> { CreateAsset(true), CreateAsset(true) };

			var validator = new AssetsValidator();

			var results = validator.Validate(list);

			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(Messages.MoreThanOnePrimaryAssets, results.Errors[0].ErrorMessage);
		}

		[Fact]
		public void ValidationSuccessful()
		{
			var list = new List<Asset> { CreateAsset(true), CreateAsset(false) };

			var validator = new AssetsValidator();

			var results = validator.Validate(list);

			Assert.True(results.IsValid);
		}

		private Asset CreateAsset(bool isPrimary)
		{
			return new Asset {Type = AssetType.IMAGE, Id = "id", Uri = "http://here.com/image.jpg", IsPrimary = isPrimary};
		}
	}
}
