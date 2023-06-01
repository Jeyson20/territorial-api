using TerritorialAPi.Models;
using TerritorialAPi.Utils;

namespace TerritorialAPi.Services.Interfaces
{
	public interface ITerritorialService
	{
		Task<ApiResponse<IReadOnlyCollection<Country>>?> GetCountries();
		Task<ApiResponse<Country>?> GetCountry(int countryId);
		Task<ApiResponse<IReadOnlyCollection<Province>>?> GetProvinces(int countryId);
		Task<ApiResponse<Province>?> GetProvince(int provinceId);
		Task<ApiResponse<IReadOnlyCollection<District>>?> GetDistricts(int provinceId);
		Task<ApiResponse<District>?> GetDistrictById(int districtId);
		Task<ApiResponse<IReadOnlyCollection<Municipality>>?> GetMunicipalities(int provinceId);
		Task<ApiResponse<Municipality>?> GetMunicipalityById(int municipalityId);
	}
}
