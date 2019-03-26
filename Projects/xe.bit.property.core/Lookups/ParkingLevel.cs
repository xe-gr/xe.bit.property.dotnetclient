using System;

namespace xe.bit.property.core.Lookups
{
	[Flags]
	public enum ParkingLevel
	{
		GROUND = 0,
		LEV_1 = 1,
		LEV_2 = 2,
		LEV_3 = 4,
		LEV_4 = 8,
		SUB_1 = 16,
		SUB_2 = 32,
		SUB_3 = 64, 
		SUB_4 = 128
	}
}