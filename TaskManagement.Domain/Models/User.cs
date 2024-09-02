
using Microsoft.AspNetCore.Identity;

namespace TaskManagement.Domain.Models
{
	public class User : IdentityUser
	{

		public ICollection<UserTask> UserTasks { get; set; }

		public ICollection<Review> Reviews { get; set; }
		public ICollection<Project> Projects { get; set; }
		public ICollection<Schedule> Schedules { get; set; }
	}
}

