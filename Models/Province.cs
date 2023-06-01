using Newtonsoft.Json;

namespace TerritorialAPi.Models
{
	public class Province
	{
		public int Id { get; set; }
		public int Code { get; set; }
		[JsonProperty("country_code")]
		public int CountryCode { get; set; }
		[JsonProperty("nombre")]
		public string? Name { get; set; }

    }
}
