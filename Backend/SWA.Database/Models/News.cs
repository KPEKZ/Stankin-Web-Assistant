using System.ComponentModel.DataAnnotations;

namespace SWA.Database.Models
{
	public class News
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }

		public string Discription { get; set; }
	}
}
