using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Models
{
	public class Schedule
	{
		[Key]
		public int ScheduleId { get; set; }

		public DayOfWeek DayOfWeek { get; set; }

		public TimeSpan Time { get; set; }
		public string UserId { get; set; }
		public User User { get; set; }

		public ICollection<UserTask> UserTasks { get; set; }

		
		public ICollection<Project> Projects { get; set; }
	}
}
