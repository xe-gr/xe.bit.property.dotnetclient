using System;
using System.IO;
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
			var p = new Package
			{
				XeAuthToken = "token", Id = "id", Trademark = "trademark", SkipAssets = false,
				Policy = PackagePolicy.RENEW_ALL_STOCK,
				Timestamp = new DateTime(2019, 04, 07, 22, 10, 00, DateTimeKind.Utc)
			};

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

			p.AddItem(ad);

			var str = p.Serialize();
			_out.WriteLine(str);

			Assert.Equal(File.ReadAllText("Fixtures\\AdResidenceAdFixture.txt"), str.Substring(0, str.Length-2));

		}
	}
}
