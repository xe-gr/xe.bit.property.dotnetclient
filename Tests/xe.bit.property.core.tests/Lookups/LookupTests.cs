using System;
using xe.bit.property.core.tests.Helpers;
using Xunit;

namespace xe.bit.property.core.tests.Lookups
{
	public class LookupTests
	{
		public string[] Values;
		public Type Type;
		public bool Ignore = true;

		[Fact]
		public virtual void EnumerateAndVerify()
		{
			if (Ignore) return;
			LookupTestHelper.EnumerateAndVerify(Type, Values);
		}
	}
}