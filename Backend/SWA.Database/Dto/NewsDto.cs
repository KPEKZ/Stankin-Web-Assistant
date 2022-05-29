using Newtonsoft.Json;

namespace SWA.Database.Dto
{
	[JsonObject]
	public class NewsDto
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Discription")]
		public string Discription { get; set; }
	}
}
