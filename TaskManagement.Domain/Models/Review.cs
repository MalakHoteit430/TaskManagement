using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Models
{
	public class Review
	{
		[Key]
		public int ReviewId { get; set; }

		public int Rating { get; set; }

		public string Comment { get; set; }
		public DateTime CreationDate { get; set; }

		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public User User { get; set; }
	}
}
