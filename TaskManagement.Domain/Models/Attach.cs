using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Models
{
	public class Attach
	{
		[Key]
		public int AttachmentId { get; set; }

		[Required]
		public string FileName { get; set; }

		public string FilePath { get; set; }

		public int? UserTaskId { get; set; }

		[ForeignKey("UserTaskId")]
		public UserTask? UserTask { get; set; }

		
	}
}
