using xe.bit.property.core.Request.Interfaces;

namespace xe.bit.property.core.tests.Request
{
	public interface ISerializer
	{
		string Serialize(IPackage package);
	}
}