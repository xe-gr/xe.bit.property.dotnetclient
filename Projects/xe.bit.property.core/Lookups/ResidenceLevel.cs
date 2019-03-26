using System;

namespace xe.bit.property.core.Lookups
{
	[Flags]
	public enum ResidenceLevel
	{
		L0 = 0,
		L1 = 1,
		L2 = 2,
		L3 = 4,
		L4 = 8,
		L5 = 16,
		L6 = 32,
		L7 = 64,
		L8 = 128,
		LH = 256,
		LHH = 512,
		S1 = 1024,
		SH = 2048
	}
}
