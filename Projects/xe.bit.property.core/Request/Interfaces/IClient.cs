namespace xe.bit.property.core.Request.Interfaces
{
	public interface IClient
	{
		void PostToBit(string packageFile, string userName, string password, bool isAddRequest);
	}
}