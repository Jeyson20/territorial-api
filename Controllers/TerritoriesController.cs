using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TerritorialAPi.Models;
using TerritorialAPi.Services.Interfaces;
using TerritorialAPi.Utils;

namespace TerritorialAPi.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class TerritoriesController : ControllerBase
	{
		private readonly ITerritorialService _territorialService;
		public TerritoriesController(ITerritorialService territorialService)
		{
			_territorialService = territorialService;
		}

		[HttpGet("Countries")]
		[SwaggerOperation(Summary = "Obtener paises")]
		public async Task<ActionResult<ApiResponse<IReadOnlyCollection<Country>>>> GetCountries()
		{
			var countries = await _territorialService.GetCountries();
			return countries?.Data.Count > 0 ? countries : NotFound();
		}

		[HttpGet("Countries/{id}")]
		[SwaggerOperation(Summary = "Obtener país según su id")]
		public async Task<ActionResult<ApiResponse<Country>>> GetCountryById(int id = 189)
		{
			var country = await _territorialService.GetCountry(id);
			return country?.Data != null ? country : NotFound();
		}

		[HttpGet("Countries/{countryId}/Provinces")]
		[SwaggerOperation(Summary = "Obtener provincias de RD")]
		public async Task<ActionResult<ApiResponse<IReadOnlyCollection<Province>>>> GetProvinces(int countryId = 8089)
		{
			var provinces = await _territorialService.GetProvinces(countryId);
			return provinces?.Data.Count > 0 ? provinces : NotFound();
		}

		[HttpGet("Countries/{countryId}/Provinces/{id}")]
		[SwaggerOperation(Summary = "Obtener provincia según su id")]

		public async Task<ActionResult<ApiResponse<Province>>> GetProvince(
			int countryId = 8089,
			int id = 10)
		{
			var province = await _territorialService.GetProvince(id);
			return province?.Data != null ? province : NotFound();
		}

		[HttpGet("Countries/{countryId}/Provinces/{provinceId}/Districts")]
		[SwaggerOperation(Summary = "Obtener distritos según la provincia del pais")]
		public async Task<ActionResult<ApiResponse<IReadOnlyCollection<District>>>> GetDistricts(
			int countryId = 8089, 
			int provinceId = 6801)
		{
			var districts = await _territorialService.GetDistricts(provinceId);
			return districts?.Data.Count > 0 ? districts : NotFound();
		}

		[HttpGet("Countries/{countryId}/Provinces/{provinceId}/Districts/{id}")]
		[SwaggerOperation(Summary = "Obtener distrito según su id")]
		public async Task<ActionResult<ApiResponse<District>>> GetDistrictById(
			int countryId = 8089,
			int provinceId = 6801,
			int id = 1)
		{
			var district = await _territorialService.GetDistrictById(id);
			return district?.Data != null ? district : NotFound();
		}

		[HttpGet("Countries/{countryId}/Provinces/{provinceId}/Municipalities")]
		[SwaggerOperation(Summary = "Obtener municipios según la provincia del pais")]
		public async Task<ActionResult<ApiResponse<IReadOnlyCollection<Municipality>>>> GetMunicipalities(
			int countryId = 8089, 
			int provinceId = 6801)
		{
			var municipalities = await _territorialService.GetMunicipalities(provinceId);
			return municipalities?.Data.Count > 0 ? municipalities : NotFound();
		}

		

		[HttpGet("Countries/{countryId}/Provinces/{provinceId}/Municipalities/{id}")]
		[SwaggerOperation(Summary = "Obtener municipio según su id")]
		public async Task<ActionResult<ApiResponse<Municipality>>> GetMunicipalities(
			int countryId = 8089,
			int provinceId = 6801,
			int id = 1)
		{
			var municipality = await _territorialService.GetMunicipalityById(id);
			return municipality?.Data != null ? municipality : NotFound();
		}
	}
}
