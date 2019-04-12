using System;
using System.Collections.Generic;
using FluentValidation.Results;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Serializers.Interfaces;

namespace xe.bit.property.core.Request.Interfaces
{
	public interface IPackage
	{
		bool IsAddRequest { get; set; }
		string XeAuthToken { get; set; }
		string SchemaVersion { get; set; }
		string Id { get; set; }
		DateTime Timestamp { get; set; }
		string StoreId { get; set; }
		string Trademark { get; set; }
		bool? SkipAssets { get; set; }
		PackagePolicy Policy { get; set; }
		List<BaseAd> Ads { get; }
		ISerializer Serializer { get; }
		IPackage AddClassified(BaseAd ad);
		IPackage ClearClassifieds();
		ValidationResult Validate();
		string Serialize();
		void Serialize(string fileName);
		void Pack(string directoryWithImages, string packedFileName);
	}
}