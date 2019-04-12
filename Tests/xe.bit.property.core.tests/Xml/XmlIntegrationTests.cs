using System;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Lookups;
using xe.bit.property.core.Request;
using Xunit;

namespace xe.bit.property.core.tests.Xml
{
	public class XmlIntegrationTests
	{
		//[Fact]	//This is an integration test and should remain commented out in source control.
		public void IntegrationTest()
		{
			var ad = new ResidenceAd
			{
				RefId = "ref id",
				OwnerId = "owner id",
				MajorPhone = "major phone",
				ItemType = ResidenceItemType.APARTMENT,
				SubType = ResidenceItemSubtype.SINGLEROOM | ResidenceItemSubtype.LOFT,
				Area = 1000.32m,
				Level = ProfLevel.L0,
				Condition = Condition.USED,
				ConstructionYear = 1970,
				ConstructionType = ConstructionType.NEOKLASIKO,
				MasterBedrooms = 2,
				Geo = { AreaId = "59-41", Latitude = 1.1m, Longitude = 2.2m },
				HasParking = false,
				ParkingType = ParkingType.CLOSED,
				InternetText = "internet text",
				BodyText = "body text",
				AddOnText = "add on text"
			};

			ad.AddAsset(new Asset
			{
				Type = AssetType.IMAGE,
				Id = "1",
				FileType = AssetFileType.JPEG,
				IsPrimary = true,
				Order = 1,
				Status = AssetStatus.ACTIVE,
				LocalFileName = "d:\\test.jpeg"
			});

			var p = Package.CreatePackage("token", "id", PackagePolicy.RENEW_ALL_STOCK, true)
				.AddClassified(ad);

			p.Timestamp = new DateTime(2019, 04, 07, 22, 10, 00, DateTimeKind.Utc);
			p.Trademark = "trademark";
			p.SkipAssets = false;

			p.Pack(null, "d:\\packed.zip");

			var client = new Client();
			client.PostToBit("d:\\packed.zip", "batchImportTest@gmail.com", "999999", true);
		}
	}
}