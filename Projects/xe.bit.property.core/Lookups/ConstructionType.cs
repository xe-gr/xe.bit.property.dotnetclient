using System;

namespace xe.bit.property.core.Lookups
{
	[Flags]
	public enum ConstructionType
	{
		LOFT = 0,
		LYOMENO = 1,
		NEOKLASIKO = 2,
		PRESERVED = 4,
		PROKAT = 8,
		ROCK = 16,
		STUDIO = 32,
		TRADITIONAL = 64,
		VILA = 128
	}
}