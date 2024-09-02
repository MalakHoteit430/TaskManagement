using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Models
{
	public class Project
	{

			[Key]
			public int ProjectId { get; set; }

			[Required]
			public string Name { get; set; }

		    public string UserId { get; set; }
		public User User { get; set; }
		public int? CategoryId { get; set; }
		public Category? Category { get; set; }
		
			public ICollection<UserTask>?  UserTasks { get; set; }

		public ICollection<Schedule>? Schedules { get; set; }
		

		}
}
