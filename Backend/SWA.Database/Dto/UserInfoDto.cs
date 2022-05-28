using Newtonsoft.Json;

namespace DatabasesSWA.ModelsDto.Dto
{
    [JsonObject]
    public class UserInfoDto
    {
        [JsonProperty("UserID")]
        public int UserID { get; set; }

        [JsonProperty("E_mail")]
        public string E_mail { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("SecondName")]
        public string SecondName { get; set; }

        [JsonProperty("Patronymic")]
        public string Patronymic { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Group")]
        public string Group { get; set; }

        [JsonProperty("Login")]
        public string Login { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("RoleName")]
        public string RoleName { get; set; }

        [JsonProperty("Permission")]
        public string Permission { get; set; }
    }
}
