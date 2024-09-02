using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Models
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }

		[Required]
		public string Name { get; set; }

		public ICollection<UserTask> UserTasks { get; set; }
		public ICollection<Project> Projects { get;set; }
	}
}
