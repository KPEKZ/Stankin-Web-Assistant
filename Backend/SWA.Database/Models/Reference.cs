using System.ComponentModel.DataAnnotations;


namespace SWA.Database.Models
{
	public class Reference
	{
		[Key]
		public int Id { get; set; }

		public string Type { get; set; }

		public string Department { get; set; }

		public string Audience { get; set; }

		public string PhoneNumber { get; set; }
	}
}
