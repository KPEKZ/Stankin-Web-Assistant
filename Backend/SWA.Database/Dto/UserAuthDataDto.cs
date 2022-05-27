using Backend.Models;
using Newtonsoft.Json;

namespace DatabasesSWA.ModelsDto.Dto
{
    [JsonObject]
    public class UserAuthDataDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Login")]
        public string Login { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("UserInfoID")]
        public virtual UserInfo UserInfoID { get; set; }
    }
}
