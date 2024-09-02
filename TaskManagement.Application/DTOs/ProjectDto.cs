using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManagement.Application.DTOs
{
	public class ProjectDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		//public string UserId { get; set; }
		//public UserDto User { get; set; }
		public int CategoryId { get; set; }
		public CategoryDto? Category { get; set; }
		public ICollection<UserTaskDto> Tasks { get; set; }

		
		
	}
}
