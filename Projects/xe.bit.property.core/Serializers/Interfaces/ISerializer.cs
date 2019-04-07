using xe.bit.property.core.Request;

namespace xe.bit.property.core.Serializers.Interfaces
{
	public interface ISerializer
	{
		string Serialize(Package package, bool isAddRequest);
	}
}