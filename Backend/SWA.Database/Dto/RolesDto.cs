using Backend.Models;
using Newtonsoft.Json;

namespace DatabasesSWA.ModelsDto.Dto
{
    [JsonObject]
    public class RolesDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("RoleName")]
        public string RoleName { get; set; }

        [JsonProperty("Permission")]
        public string Permission { get; set; }

        [JsonProperty("UserInfoID")]
        public virtual UserInfo UserInfoID { get; set; }
    }
}
