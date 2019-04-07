using System;

namespace xe.bit.property.core.Lookups
{
	[Flags]
	public enum ResidenceHolLevel
	{
		L0 = 1,
		L1 = 2,
		L2 = 4,
		L3 = 8,
		L4 = 16,
		L5 = 32,
		L6 = 64,
		L7 = 128,
		L8 = 256,
		LH = 512,
		LHH = 1024,
		S1 = 2048,
		SH = 4096
	}
}