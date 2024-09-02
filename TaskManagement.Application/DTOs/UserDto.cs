using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.DTOs
{
	public class UserDto
	{
		public string Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public ICollection<UserTaskDto> Tasks { get; set; }
		public ICollection<ReviewDto> Reviews { get; set; }
		public ICollection<ScheduleDto> Schedules { get; set; }
		public ICollection<ProjectDto> Projects { get; set; }
	}
}
