using System;
using System.IO;
using System.Text;
using xe.bit.property.core.Ads;
using xe.bit.property.core.Lookups;
using xe.bit.property.core.Request;
using Xunit;
using Xunit.Abstractions;

namespace xe.bit.property.core.tests.xml
{
	public class XmlTests
	{
		private readonly ITestOutputHelper _out;

		public XmlTests(ITestOutputHelper testOutputHelper)
		{
			_out = testOutputHelper;
		}

		[Fact]
		public void VerifyPackageWithResidenceAdXmlSerialization()
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
				Geo = {AreaId = "59-41", Latitude = 1.1m, Longitude = 2.2m},
				HasParking = false,
				ParkingType = ParkingType.CLOSED
			};

			ad.AddAsset(new Asset
			{
				Type = AssetType.IMAGE,
				Id = "1",
				FileType = AssetFileType.JPEG,
				IsPrimary = true,
				Order = 1,
				Status = AssetStatus.ACTIVE,
				LocalFileName = "local\\image.jpeg"
			});

			var p = Package.CreatePackage("token", "id", PackagePolicy.RENEW_ALL_STOCK, true)
				.AddClassified(ad);

			p.Timestamp = new DateTime(2019, 04, 07, 22, 10, 00, DateTimeKind.Utc);
			p.Trademark = "trademark";
			p.SkipAssets = false;

			var str = p.Serialize();
			_out.WriteLine(str);

			Assert.Equal(File.ReadAllText("Fixtures\\AdResidenceAdFixture.txt", Encoding.UTF8), str);
		}
	}
}