using xe.bit.property.core.Request;

namespace xe.bit.property.core.tests.Request
{
	public interface ISerializer
	{
		string Serialize(Package package);
	}
}