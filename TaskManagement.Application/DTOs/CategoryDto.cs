using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.DTOs
{
	public class CategoryDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<UserTaskDto> UserTasks { get; set; }
		public ICollection<ProjectDto> Projects { get; set; }
	}
}
