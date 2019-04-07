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
		public void CreatePackage()
		{
			// WIP
			var p = new Package {XeAuthToken = "token", Id = "id", Trademark = "trademark", SkipAssets = false};

			var ad = CreateAd();
			p.AddItem(ad);

			var str = p.Serialize();
			_out.WriteLine(str);

		}

		private ResidenceAd CreateAd()
		{
			return new ResidenceAd
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
				MasterBedrooms = 2,
				Geo = { AreaId = "59-41" }
			};
		}
	}
}
