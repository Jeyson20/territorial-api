using Newtonsoft.Json;

namespace TerritorialAPi.Models
{
	public class District
	{
		public int Id { get; set; }
		public int Code { get; set; }
		[JsonProperty("province_code")]
		public int ProvinceCode { get; set; }
		[JsonProperty("nombre")]
		public string? Name { get; set; }
	}
}
