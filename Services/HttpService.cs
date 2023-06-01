using TerritorialAPi.Services.Interfaces;

namespace TerritorialAPi.Services
{
	public class HttpService : IHttpService
	{
		private readonly HttpClient _httpClient;
		public HttpService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<HttpResponseMessage> GetAsync(string endpoint)
		{
			return await _httpClient.GetAsync(endpoint);
		}
	}
}
