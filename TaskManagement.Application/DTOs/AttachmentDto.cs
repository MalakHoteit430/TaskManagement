using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.DTOs
{
	public class AttachmentDto
	{
		public int Id { get; set; }
		public string FilePath { get; set; }
		public string FileName { get; set; }
		public int UserTaskId { get; set; }
	}
}
