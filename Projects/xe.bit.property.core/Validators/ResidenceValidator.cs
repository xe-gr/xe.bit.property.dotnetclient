using System;
using FluentValidation;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Errors;
using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.Validators
{
	public class ResidenceValidator : AbstractValidator<ResidenceAd>
	{
		protected void AddOtherRules()
		{
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

			RuleFor(ad => ComplexFlagCheck(ad.HasStorage, ad.StorageArea.HasValue))
				.Equal(false)
				.WithMessage(Messages.HasStorageConstraint);

			RuleFor(ad => ComplexFlagCheck(ad.HasSemiOpenSpaces, ad.SemiOpenSpacesArea.HasValue))
				.Equal(false)
				.WithMessage(Messages.HasSemiOpenSpacesConstraint);

			RuleFor(ad => ComplexFlagCheck(ad.HasGarden, ad.GardenArea.HasValue))
				.Equal(false)
				.WithMessage(Messages.HasGardenConstraint);

			RuleFor(ad => ComplexFlagCheck(ad.HasTerraceArea, ad.TerraceArea.HasValue))
				.Equal(false)
				.WithMessage(Messages.HasTerraceConstraint);

			RuleFor(ad => (ad.Floors.HasValue ^ ad.FloorsArea.HasValue) && (ad.Floors.HasValue && ad.Floors != 0 && !ad.FloorsArea.HasValue))
				.Equal(false)
				.WithMessage(Messages.FloorsConstraint);

			RuleFor(ad => ComplexFlagCheck(ad.HasParking, ad.ParkingType.HasValue))
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

		/// <summary>
		/// Checks valid conditions if a flag and a value are specified (for example,
		/// hasTerrace and TerraceArea). We want both these to have values, but if
		/// a flag is specified and is false, we do not care of the specified value
		/// (for example if hasTerrace has a value and is false, this is allowed).
		/// </summary>
		/// <returns></returns>
		private bool ComplexFlagCheck(bool? flag, bool hasValue)
		{
			if (flag.HasValue && flag.Value == false && hasValue)
			{
				return true;
			}

			if (!flag.HasValue && hasValue)
			{
				return true;
			}

			return false;
		}
	}
}
