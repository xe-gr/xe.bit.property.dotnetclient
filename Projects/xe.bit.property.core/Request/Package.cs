﻿using System;
using System.Collections.Generic;
using FluentValidation.Results;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Serializers;
using xe.bit.property.core.Serializers.Interfaces;
using xe.bit.property.core.Utility;
using xe.bit.property.core.Validators;

namespace xe.bit.property.core.Request
{
	public class Package
	{
		public virtual bool IsAddRequest { get; set; } = true;
		public virtual string XeAuthToken { get; set; }
		public virtual string SchemaVersion { get; set; } = "1.1";
		public virtual string Id { get; set; }
		public virtual DateTime Timestamp { get; set; } = DateTime.UtcNow;
		public virtual string StoreId { get; set; }
		public virtual string Trademark { get; set; }
		public virtual bool? SkipAssets { get; set; }
		public virtual PackagePolicy Policy { get; set; } = PackagePolicy.INCREMENTAL;

		public virtual List<BaseAd> Ads { get; protected set; } = new List<BaseAd>();

		public ISerializer Serializer { get; } = new XmlPackageSerializer();

		public Package AddClassified(BaseAd ad)
		{
			Ads.Add(ad);

			return this;
		}

		public Package ClearClassifieds()
		{
			Ads.Clear();

			return this;
		}

		public ValidationResult Validate()
		{
			var result = new PackageValidator().Validate(this);

			foreach (var ad in Ads)
			{
				result = ValidationChain.ChainValidators(ad, ValidationChain.Chain(result, ad.Validate()));
			}

			return result;
		}

		public string Serialize()
		{
			var result = Validate();
			if (!result.IsValid)
			{
				throw new InvalidOperationException("Invalid package. Run Validate() to see the errors");
			}

			return Serializer.Serialize(this, IsAddRequest);
		}

		public static Package CreatePackage(string xeAuthToken, PackagePolicy policy, bool isAddRequest)
		{
			return CreatePackage(xeAuthToken, $"{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid():N}", policy, isAddRequest);
		}

		public static Package CreatePackage(string xeAuthToken, string id, PackagePolicy policy, bool isAddRequest)
		{
			return new Package {Id = id, IsAddRequest = isAddRequest, XeAuthToken = xeAuthToken, Policy = policy};
		}
	}
}