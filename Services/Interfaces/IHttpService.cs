namespace TerritorialAPi.Services.Interfaces
{
	public interface IHttpService
	{
		Task<HttpResponseMessage> GetAsync(string endpoint);
	}
}
