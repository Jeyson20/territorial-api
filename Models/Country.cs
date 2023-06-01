using Newtonsoft.Json;

namespace TerritorialAPi.Models
{
	public class Country
	{
		public int Id { get; set; }
		public int Code { get; set; }
		[JsonProperty("iso_code")]
		public string? IsoCode { get; set; }
		[JsonProperty("nombre")]
		public string? Name { get; set; }

	}
}
