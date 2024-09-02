using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.DTOs
{
	public class UserTaskDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int CategoryId { get; set; }
		public CategoryDto? Category { get; set; }
		public int ProjectId { get; set; }
		public ProjectDto? Project { get; set; }

		public ICollection<AttachmentDto> Attachments { get; set; }
		public string UserId { get; set; }
		public UserDto User { get; set; }
	}
}
