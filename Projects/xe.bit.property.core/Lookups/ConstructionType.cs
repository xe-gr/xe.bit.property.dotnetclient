using System;

namespace xe.bit.property.core.Lookups
{
	[Flags]
	public enum ConstructionType
	{
		LOFT = 1,
		LYOMENO = 2,
		NEOKLASIKO = 4,
		PRESERVED = 8,
		PROKAT = 16,
		ROCK = 32,
		STUDIO = 64,
		TRADITIONAL = 128,
		VILA = 256
	}
}