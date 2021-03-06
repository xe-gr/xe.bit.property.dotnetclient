﻿using FluentValidation;
using xe.bit.property.core.Errors;
using xe.bit.property.core.Lookups;

namespace xe.bit.property.core.Validators
{
	public class ResidenceAdValidator : ResidenceValidator
	{
		public ResidenceAdValidator()
		{
			RuleFor(ad => ad.AdType)
				.Equal(ItemType.re_residence)
				.WithMessage(Messages.AddTypeMustBeResidence);

			AddOtherRules();
		}
	}
}
