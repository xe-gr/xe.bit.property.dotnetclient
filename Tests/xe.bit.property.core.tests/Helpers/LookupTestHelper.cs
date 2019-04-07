using System;
using Xunit;

namespace xe.bit.property.core.tests.Helpers
{
	public class LookupTestHelper
	{
		public static void EnumerateAndVerify(Type enumeration, string[] expectedValues)
		{
			var output = Enum.GetNames(enumeration);

			Assert.Equal(expectedValues.Length, output.Length);

			foreach (var value in expectedValues)
			{
				Assert.Contains(value, output);
			}
		}

		public static void VerifyFlags(Type enumeration, string[] expectedValues)
		{
			var power = 1;

			foreach (var value in expectedValues)
			{
				var done = Enum.TryParse(enumeration, value, false, out var o);

				Assert.True(done);
				Assert.Equal(power, (int) o);

				power *= 2;
			}
		}
	}
}