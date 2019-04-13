using System;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Errors;
using xe.bit.property.core.Lookups;
using xe.bit.property.core.Validators;
using Xunit;

namespace xe.bit.property.core.tests.Validators
{
	public class ResidenceAdValidatorTests
	{
		[Fact]
		public void SubTypeMustHaveValueWhenApartment()
		{
			var ad = CreateAd();
			ad.ItemType = ResidenceItemType.APARTMENT;

			var validator = new ResidenceAdValidator();

			var results = validator.Validate(ad);

			Assert.False(results.IsValid);
			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(Messages.ResidenceSubTypeMustHaveValue, results.Errors[0].ErrorMessage);
		}

		[Theory]
		[InlineData(ResidenceItemType.BUILDING)]
		[InlineData(ResidenceItemType.HOUSE)]
		[InlineData(ResidenceItemType.OIKEIA)]
		[InlineData(ResidenceItemType.SPLIT_LEVEL)]
		public void SubTypeMustNotHaveValueWhenNotApartment(ResidenceItemType itemType)
		{
			var ad = CreateAd();
			ad.ItemType = itemType;
			ad.SubType = ResidenceItemSubtype.FLOORFLAT;

			var validator = new ResidenceAdValidator();

			var results = validator.Validate(ad);

			Assert.False(results.IsValid);
			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(Messages.ResidenceSubTypeMustBeNull, results.Errors[0].ErrorMessage);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public void ValidateArea(bool nullable)
		{
			var ad = CreateAd();
			ad.Area = nullable ? (decimal?)null : 0;

			var validator = new ResidenceAdValidator();

			var results = validator.Validate(ad);

			Assert.False(results.IsValid);
			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(nullable ? Messages.AreaMustHaveValue : Messages.AreaMustHavePositiveValue, results.Errors[0].ErrorMessage);
		}

		[Fact]
		public void ValidateLevel()
		{
			var ad = CreateAd();
			ad.Level = null;

			var validator = new ResidenceAdValidator();

			var results = validator.Validate(ad);

			Assert.False(results.IsValid);
			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(Messages.LevelMustHaveValue, results.Errors[0].ErrorMessage);
		}

		[Theory]
		[InlineData(1900)]
		[InlineData(2048)]
		public void ValidateConstructionYear(int year)
		{
			var ad = CreateAd();
			ad.ConstructionYear = year;

			var validator = new ResidenceAdValidator();

			var results = validator.Validate(ad);

			Assert.False(results.IsValid);
			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(Messages.ConstructionYearOutOfBounds, results.Errors[0].ErrorMessage);
		}

		[Theory]
		[InlineData(1900)]
		[InlineData(2048)]
		public void ValidateRefurbishmentYear(int year)
		{
			var ad = CreateAd();
			ad.RefurbishmentYear = year;

			var validator = new ResidenceAdValidator();

			var results = validator.Validate(ad);

			Assert.False(results.IsValid);
			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(Messages.RefurbishmentYearOutOfBounds, results.Errors[0].ErrorMessage);
		}

		[Fact]
		public void ValidateMoreBedroomsThanMasterBedrooms()
		{
			var ad = CreateAd();
			ad.Bedrooms = 10;
			ad.MasterBedrooms = 10;

			var validator = new ResidenceAdValidator();

			var results = validator.Validate(ad);

			Assert.False(results.IsValid);
			Assert.Equal(1, results.Errors.Count);
			Assert.Equal(Messages.BedroomsOutOfBound, results.Errors[0].ErrorMessage);
		}

		[Theory]
		[InlineData(true, false, true, 1, null)]
		[InlineData(false, true, false, 1, null)]
		[InlineData(false, false, true, 1, null)]
		[InlineData(true, false, false, 1, Messages.HasStorageConstraint)]
		[InlineData(false, false, false, 1, Messages.HasStorageConstraint)]
		public void StorageConstraint(bool isStorageFlagNull, bool value, bool isStorageAreaNull, decimal storageArea, string expectedError)
		{
			CheckFlagConstraints(isStorageFlagNull, ad => ad.HasStorage = value, isStorageAreaNull,
				ad => ad.StorageArea = storageArea, expectedError);
		}

		[Theory]
		[InlineData(true, false, true, 1, null)]
		[InlineData(false, true, false, 1, null)]
		[InlineData(false, false, true, 1, null)]
		[InlineData(true, false, false, 1, Messages.HasSemiOpenSpacesConstraint)]
		[InlineData(false, false, false, 1, Messages.HasSemiOpenSpacesConstraint)]
		public void SemiOpenSpaceConstraint(bool isSemiOpenFlagNull, bool value, bool isSemiOpenSpaceNull, decimal semiOpenSpaceArea, string expectedError)
		{
			CheckFlagConstraints(isSemiOpenFlagNull, ad => ad.HasSemiOpenSpaces = value, isSemiOpenSpaceNull,
				ad => ad.SemiOpenSpacesArea = semiOpenSpaceArea, expectedError);
		}

		[Theory]
		[InlineData(true, false, true, 1, null)]
		[InlineData(false, true, false, 1, null)]
		[InlineData(false, false, true, 1, null)]
		[InlineData(true, false, false, 1, Messages.HasGardenConstraint)]
		[InlineData(false, false, false, 1, Messages.HasGardenConstraint)]
		public void GardenConstraint(bool isGardenFlagNull, bool value, bool isGardenAreaNull, decimal gardenArea, string expectedError)
		{
			CheckFlagConstraints(isGardenFlagNull, ad => ad.HasGarden = value, isGardenAreaNull,
				ad => ad.GardenArea = gardenArea, expectedError);
		}

		[Theory]
		[InlineData(true, false, true, 1, null)]
		[InlineData(false, true, false, 1, null)]
		[InlineData(false, false, true, 1, null)]
		[InlineData(true, false, false, 1, Messages.HasTerraceConstraint)]
		[InlineData(false, false, false, 1, Messages.HasTerraceConstraint)]
		public void TerraceConstraint(bool isTerraceFlagNull, bool value, bool isTerraceAreaNull, decimal terraceArea, string expectedError)
		{
			CheckFlagConstraints(isTerraceFlagNull, ad => ad.HasTerraceArea = value, isTerraceAreaNull,
				ad => ad.TerraceArea = terraceArea, expectedError);
		}

		[Theory]
		[InlineData(true, false, true, ParkingType.CLOSED, null)]
		[InlineData(false, true, false, ParkingType.CLOSED, null)]
		[InlineData(false, false, true, ParkingType.CLOSED, null)]
		[InlineData(true, false, false, ParkingType.CLOSED, Messages.HasParkingConstraint)]
		[InlineData(false, false, false, ParkingType.CLOSED, Messages.HasParkingConstraint)]

		public void ParkingConstraint(bool isParkingFlagNull, bool value, bool isParkingTypeNull, ParkingType parkingType, string expectedError)
		{
			CheckFlagConstraints(isParkingFlagNull, ad => ad.HasParking = value, isParkingTypeNull,
				ad => ad.ParkingType = parkingType, expectedError);
		}

		[Theory]
		[InlineData(true, 1, true, 1, null)]
		[InlineData(false, 1, false, 1, null)]
		[InlineData(false, 1, true, 1, Messages.FloorsConstraint)]
		[InlineData(true, 1, false, 1, null)]
		[InlineData(false, 0, false, 1, null)]

		public void FloorsConstraint(bool isFloorsFlagNull, int value, bool isFloorsAreaNull, decimal floorsArea, string expectedError)
		{
			CheckFlagConstraints(isFloorsFlagNull, ad => ad.Floors = value, isFloorsAreaNull,
				ad => ad.FloorsArea = floorsArea, expectedError);
		}

		private void CheckFlagConstraints(bool isFlagSpecified, Action<ResidenceAd> flagAssignment,
			bool isValueSpecified, Func<ResidenceAd, object> valueAssignment, string expectedError)
		{
			var ad = CreateAd();
			if (!isFlagSpecified)
			{
				flagAssignment(ad);
			}

			if (!isValueSpecified)
			{
				valueAssignment(ad);
			}

			var validator = new ResidenceAdValidator();

			var results = validator.Validate(ad);

			if (string.IsNullOrEmpty(expectedError))
			{
				Assert.True(results.IsValid);
			}
			else
			{
				Assert.False(results.IsValid);
				Assert.Equal(1, results.Errors.Count);
				Assert.Equal(expectedError, results.Errors[0].ErrorMessage);
			}
		}

		private ResidenceAd CreateAd()
		{
			return new ResidenceAd
			{
				ItemType = ResidenceItemType.BUILDING,
				Area = 100,
				Level = ProfLevel.L0,
				Condition = Condition.USED,
				ConstructionYear = 1970,
				MasterBedrooms = 2,
				Geo = { AreaId = "59-41" }
			};
		}
	}
}
