
namespace Backend.Models
{
	public class Roles
	{
		public int Id { get; set; }
		public string RoleName { get; set; }

		public string Permission { get; set; }

		public virtual UserInfo UserInfoID { get; set; }
	}
}
