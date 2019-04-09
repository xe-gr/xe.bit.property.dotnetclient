using System.IO;
using xe.bit.property.core.Request;

namespace xe.bit.property.core.Serializers.Interfaces
{
	public interface ISerializer
	{
		string Serialize(Package package, bool isAddRequest);
		void Serialize(Package package, bool isAddRequest, string fileName);
		void Serialize(Stream stream, Package package, bool isAddRequest);
	}
}