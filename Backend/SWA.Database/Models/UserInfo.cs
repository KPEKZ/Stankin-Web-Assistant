
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
	public class UserInfo
	{
        [Key]		
		public int UserID { get; set; }

		public string E_mail { get; set; }

		public string FirstName { get; set; }

		public string SecondName { get; set; }

		public string Patronymic { get; set; }

		public string PhoneNumber { get; set; }
	}
}
