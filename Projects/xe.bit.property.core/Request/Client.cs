using System;
using RestSharp;

namespace xe.bit.property.core.Request
{
	public class Client
	{
		public void PostToBit(string packageFile, string userName, string password, bool isAddRequest)
		{
			var request = new RestRequest(isAddRequest ? "/request/add" : "request/remove");
			request.AddHeader("Content-Type", "multipart/form-data");
			request.AddParameter("username", userName);
			request.AddParameter("password", password);
			request.AddFile("file", packageFile, "application/zip");

			var client = new RestClient("http://import.xe.gr");
			var response = client.Post(request);

			if (!response.IsSuccessful)
			{
				throw new InvalidOperationException($"Request failed - {response.ErrorMessage}");
			}

			if (response.Content != "REQUEST UPLOADED SUCCESSFULLY")
			{
				throw new InvalidOperationException($"Request failed - {response.Content}");
			}
		}
	}
}