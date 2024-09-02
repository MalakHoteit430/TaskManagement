using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace TaskManagement.Domain.Models
{
	public class UserTask
	{
		[Key]
		public int UserTaskId { get; set; }

		[Required]
		public string Title { get; set; }
		public int? Priority { get; set; }

		public string Description { get; set; }

		public DateTime DueDate { get; set; }

		public bool IsCompleted { get; set; }

		public int? ProjectId { get; set; }

		[ForeignKey("ProjectId")]
		public Project? Project { get; set; }

		public int? CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public Category? Category { get; set; }

		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public User User { get; set; }
		public ICollection<Schedule>? Schedules { get; set; }
		public ICollection<Attach>? Attachments { get; set; }
		
	}
}
