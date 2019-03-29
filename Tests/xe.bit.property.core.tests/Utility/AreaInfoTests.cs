using System.Collections.Generic;
using xe.bit.property.core.Utility;
using Xunit;

namespace xe.bit.property.core.tests.Utility
{
	public class AreaInfoTests
	{
		[Fact]
		public void VerifyNumberOfAreaExceptions()
		{
			Assert.Equal(33, AreaInfo.NumberOfExceptions);
		}

		[Fact]
		public void VerifyAreaExceptions()
		{
			var exceptions = new List<string>
			{
				"59-15", "59-23", "59-26", "59-3", "59-44", "47", "65", "66", "67", "68", "58", "59", "60", "61", "62",
				"63", "64", "13", "14", "36", "48", "50", "56", "88", "89", "91", "94", "95", "96", "97", "98", "99",
				"100000"
			};

			foreach (var exception in exceptions)
			{
				Assert.True(AreaInfo.IsAreaIdException(exception));
			}
		}

		[Fact]
		public void SampleAreaInfoParsed()
		{
			Assert.True(AreaInfo.IsAreaIdValid("1133"));
			Assert.True(AreaInfo.IsAreaIdValid("58"));
		}

		[Fact]
		public void VerifyAreaInfoDetectsInvalidArea()
		{
			Assert.False(AreaInfo.IsAreaIdValid("Map_Id"));
		}

		[Fact]
		public void SampleAreaInfoLabel()
		{
			Assert.Equal("Άγιος Σώστης, Νέος Κόσμος", AreaInfo.GetMapLabelOfAreaId("59-28-105"));
			Assert.Equal("Θράκη", AreaInfo.GetMapLabelOfAreaId("96"));
		}
	}
}
