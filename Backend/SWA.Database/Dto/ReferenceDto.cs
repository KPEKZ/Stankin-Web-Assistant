using Newtonsoft.Json;

namespace SWA.Database.Dto
{
	[JsonObject]
	public class ReferenceDto
	{
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Department")]
        public string Department { get; set; }

        [JsonProperty("Audience")]
        public string Audience { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
