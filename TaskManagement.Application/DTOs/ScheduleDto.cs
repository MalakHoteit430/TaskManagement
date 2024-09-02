using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.DTOs
{
	public class ScheduleDto
	{
		public int Id { get; set; }

		public DayOfWeek DayOfWeek { get; set; }

		public ICollection<UserTaskDto> Tasks { get; set; }
		public ICollection<ProjectDto> Projects { get; set; }
	}
}
