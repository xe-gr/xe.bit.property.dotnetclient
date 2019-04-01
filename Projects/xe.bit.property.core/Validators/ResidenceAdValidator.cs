using System;
using FluentValidation;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Errors;
using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.Validators
{
	public class ResidenceAdValidator : AbstractValidator<ResidenceAd>
	{
		public ResidenceAdValidator()
		{
			RuleFor(ad => ad.AdType)
				.Equal(ItemType.re_residence)
				.WithMessage(Messages.AddTypeMustBeResidence);

			RuleFor(ad => ad.ItemType == ResidenceItemType.APARTMENT && !ad.SubType.HasValue)
				.Equal(false)
				.WithMessage(Messages.ResidenceSubTypeMustHaveValue);

			RuleFor(ad => ad.ItemType != ResidenceItemType.APARTMENT && ad.SubType.HasValue)
				.Equal(false)
				.WithMessage(Messages.ResidenceSubTypeMustBeNull);

			RuleFor(ad => ad.Area)
				.NotNull().WithMessage(Messages.AreaMustHaveValue);

			When(ad => ad.Area.HasValue, () =>
			{
				RuleFor(ad => ad.Area.Value)
					.GreaterThan(0).WithMessage(Messages.AreaMustHavePositiveValue);
			});

			RuleFor(ad => ad.Level)
				.NotNull()
				.WithMessage(Messages.LevelMustHaveValue);

			RuleFor(ad => ad.Condition)
				.NotNull()
				.WithMessage(Messages.ConditionMustHaveValue);

			RuleFor(ad => ad.ConstructionYear)
				.GreaterThan(1900).WithMessage(Messages.ConstructionYearOutOfBounds)
				.LessThanOrEqualTo(DateTime.UtcNow.Year).WithMessage(Messages.ConstructionYearOutOfBounds);

			When(ad => ad.RefurbishmentYear.HasValue, () =>
			{
				RuleFor(ad => ad.RefurbishmentYear.Value)
					.GreaterThan(1900).WithMessage(Messages.RefurbishmentYearOutOfBounds)
					.LessThanOrEqualTo(DateTime.UtcNow.Year).WithMessage(Messages.RefurbishmentYearOutOfBounds);
			});

			RuleFor(ad => ad.Bedrooms - ad.MasterBedrooms)
				.GreaterThan(0)
				.WithMessage(Messages.BedroomsOutOfBound);

			RuleFor(ad => (ad.HasStorage.HasValue ^ ad.StorageArea.HasValue) && (ad.HasStorage.HasValue && !ad.HasStorage.Value && !ad.StorageArea.HasValue))
				.Equal(false)
				.WithMessage(Messages.HasStorageConstraint);

			RuleFor(ad => (ad.HasSemiOpenSpaces.HasValue ^ ad.SemiOpenSpacesArea.HasValue) && (ad.HasSemiOpenSpaces.HasValue && !ad.HasSemiOpenSpaces.Value && !ad.SemiOpenSpacesArea.HasValue))
				.Equal(false)
				.WithMessage(Messages.HasSemiOpenSpacesConstraint);

			RuleFor(ad => (ad.HasGarden.HasValue ^ ad.GardenArea.HasValue) && (ad.HasGarden.HasValue && !ad.HasGarden.Value && !ad.GardenArea.HasValue))
				.Equal(false)
				.WithMessage(Messages.HasGardenConstraint);

			RuleFor(ad => (ad.HasTerraceArea.HasValue ^ ad.TerraceArea.HasValue) && (ad.HasTerraceArea.HasValue && !ad.HasTerraceArea.Value && !ad.TerraceArea.HasValue))
				.Equal(false)
				.WithMessage(Messages.HasTerraceConstraint);

			RuleFor(ad => (ad.Floors.HasValue ^ ad.FloorsArea.HasValue) && (ad.Floors.HasValue && ad.Floors != 0 && !ad.FloorsArea.HasValue))
				.Equal(false)
				.WithMessage(Messages.FloorsConstraint);

			RuleFor(ad => (ad.HasParking.HasValue ^ ad.ParkingType.HasValue) && (ad.HasParking.HasValue && !ad.HasParking.Value && !ad.ParkingType.HasValue))
				.Equal(false)
				.WithMessage(Messages.HasParkingConstraint);

			RuleFor(ad => ad.Geo)
				.Custom((geo, context) =>
				{
					new GeoValidator().Validate(geo, context);
				});

			RuleFor(ad => ad.Assets)
				.Custom((assets, context) =>
				{
					new AssetsValidator().Validate(assets, context);
				});
		}
	}
}
