using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentValidation.Results;
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Lookups;
using xe.bit.property.core.Request.Interfaces;
using xe.bit.property.core.Serializers;
using xe.bit.property.core.Serializers.Interfaces;
using xe.bit.property.core.Utility;
using xe.bit.property.core.Validators;

namespace xe.bit.property.core.Request
{
	public class Package : IPackage
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

		public IPackage AddClassified(BaseAd ad)
		{
			Ads.Add(ad);

			return this;
		}

		public IPackage ClearClassifieds()
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
			ValidatePackage();

			return Serializer.Serialize(this, IsAddRequest);
		}

		public void Serialize(string fileName)
		{
			ValidatePackage();

			Serializer.Serialize(this, IsAddRequest, fileName);
		}

		public void Pack(string directoryWithImages, string packedFileName)
		{
			ValidatePackage();

			using (var ms = new MemoryStream())
			using (var archive = ZipArchive.Create())
			{
				var fi = new FileInfo(packedFileName);
				
				Serializer.Serialize(ms, this, IsAddRequest);
				archive.AddEntry(fi.Name.Replace(fi.Extension, ".xml"), ms, true);

				if (SkipAssets.HasValue && !SkipAssets.Value)
				{
					foreach (var ad in Ads)
					{
						if (ad is ResidenceAd residenceAd)
						{
							foreach (var asset in residenceAd.Assets.Where(x => x.Type == AssetType.IMAGE))
							{
								var name = string.IsNullOrEmpty(asset.LocalFileName)
									? Path.Combine(directoryWithImages, asset.Uri)
									: asset.LocalFileName;

								try
								{
									archive.AddEntry(asset.Uri, name);
								}
								catch (FileNotFoundException)
								{
									throw new InvalidOperationException($"Asset located at [{name}] was not found");
								}
							}
						}
					}
				}

				archive.SaveTo(packedFileName, CompressionType.Deflate);
			}
		}

		public static IPackage CreatePackage(string xeAuthToken, PackagePolicy policy, bool isAddRequest)
		{
			return CreatePackage(xeAuthToken, $"{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid():N}", policy, isAddRequest);
		}

		public static IPackage CreatePackage(string xeAuthToken, string id, PackagePolicy policy, bool isAddRequest)
		{
			return new Package {Id = id, IsAddRequest = isAddRequest, XeAuthToken = xeAuthToken, Policy = policy};
		}

		private void ValidatePackage()
		{
			var result = Validate();
			if (!result.IsValid)
			{
				throw new InvalidOperationException("Invalid package. Run Validate() to see the errors");
			}
		}
	}
}