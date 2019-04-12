using System.IO;
using xe.bit.property.core.Request.Interfaces;

namespace xe.bit.property.core.Serializers.Interfaces
{
	public interface ISerializer
	{
		string Serialize(IPackage package, bool isAddRequest);
		void Serialize(IPackage package, bool isAddRequest, string fileName);
		void Serialize(Stream stream, IPackage package, bool isAddRequest);
	}
}