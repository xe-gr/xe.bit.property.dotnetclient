using System;

namespace xe.bit.property.core.Lookups
{
	[Flags]
	public enum ParkingLevel
	{
		GROUND = 1,
		LEV_1 = 2,
		LEV_2 = 4,
		LEV_3 = 8,
		LEV_4 = 16,
		SUB_1 = 32,
		SUB_2 = 64,
		SUB_3 = 128, 
		SUB_4 = 256
	}
}