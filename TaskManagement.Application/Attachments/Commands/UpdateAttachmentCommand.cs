using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Attachments.Commands
{
	public class UpdateAttachmentCommand:IRequest<AttachmentDto>
	{
		public int Id { get; set; }
		public string FileName { get; set; }
		public string FilePath { get; set; }
	}
}
