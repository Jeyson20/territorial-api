using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TerritorialAPi.Models;
using TerritorialAPi.Services.Interfaces;
using TerritorialAPi.Utils;

namespace TerritorialAPi.Services
{
	public class TerritorialService : ITerritorialService
	{
		private readonly IHttpService _httpService;
		private readonly TerritorialConfig _config;

		public TerritorialService(IHttpService httpService, IOptions<TerritorialConfig> config)
		{
			_httpService = httpService;
			_config = config.Value;
		}



		public async Task<ApiResponse<IReadOnlyCollection<Country>>?> GetCountries()
		{
			try
			{
				string endpoint = $"{_config.BaseUrl}/api/paises";
				var response = await _httpService.GetAsync(endpoint);

				if (response.IsSuccessStatusCode)
				{
					var jsonResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<ApiResponse<IReadOnlyCollection<Country>>>(jsonResponse);
				}

				return new ApiResponse<IReadOnlyCollection<Country>>();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<ApiResponse<Country>?> GetCountry(int countryId)
		{
			try
			{
				string endpoint = $"{_config.BaseUrl}/api/paises/{countryId}/show";
				var response = await _httpService.GetAsync(endpoint);

				if (response.IsSuccessStatusCode)
				{
					var jsonResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<ApiResponse<Country>>(jsonResponse);
				}

				return new ApiResponse<Country>();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<ApiResponse<IReadOnlyCollection<Province>>?> GetProvinces(int countryId)
		{
			try
			{
				string endpoint = $"{_config.BaseUrl}/api/provincias?country_code={countryId}";
				var response = await _httpService.GetAsync(endpoint);

				if (response.IsSuccessStatusCode)
				{
					var jsonResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<ApiResponse<IReadOnlyCollection<Province>>>(jsonResponse);
				}

				return new ApiResponse<IReadOnlyCollection<Province>>();
			}
			catch (Exception)
			{

				throw;
			}

		}

		public async Task<ApiResponse<Province>?> GetProvince(int provinceId)
		{
			try
			{
				string endpoint = $"{_config.BaseUrl}/api/provincias/{provinceId}/show";
				var response = await _httpService.GetAsync(endpoint);

				if (response.IsSuccessStatusCode)
				{
					var jsonResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<ApiResponse<Province>>(jsonResponse);
				}

				return new ApiResponse<Province>();
			}
			catch (Exception)
			{

				throw;
			}

		}

		public async Task<ApiResponse<IReadOnlyCollection<District>>?> GetDistricts(int provinceId)
		{

			try
			{
				string endpoint = $"{_config.BaseUrl}/api/distritos?province_code={provinceId}";
				var response = await _httpService.GetAsync(endpoint);

				if (response.IsSuccessStatusCode)
				{
					var jsonResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<ApiResponse<IReadOnlyCollection<District>>>(jsonResponse);
				}

				return new ApiResponse<IReadOnlyCollection<District>>();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<ApiResponse<IReadOnlyCollection<Municipality>>?> GetMunicipalities(int provinceId)
		{
			try
			{
				string endpoint = $"{_config.BaseUrl}/api/municipios?province_code={provinceId}";
				var response = await _httpService.GetAsync(endpoint);

				if (response.IsSuccessStatusCode)
				{
					var jsonResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<ApiResponse<IReadOnlyCollection<Municipality>>>(jsonResponse);
				}

				return new ApiResponse<IReadOnlyCollection<Municipality>>();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<ApiResponse<District>?> GetDistrictById(int districtId)
		{
			try
			{
				string endpoint = $"{_config.BaseUrl}/api/distritos/{districtId}/show";
				var response = await _httpService.GetAsync(endpoint);

				if (response.IsSuccessStatusCode)
				{
					var jsonResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<ApiResponse<District>>(jsonResponse);
				}

				return new ApiResponse<District>();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<ApiResponse<Municipality>?> GetMunicipalityById(int municipalityId)
		{
			try
			{
				string endpoint = $"{_config.BaseUrl}/api/municipios/{municipalityId}/show";
				var response = await _httpService.GetAsync(endpoint);

				if (response.IsSuccessStatusCode)
				{
					var jsonResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<ApiResponse<Municipality>>(jsonResponse);
				}

				return new ApiResponse<Municipality>();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

