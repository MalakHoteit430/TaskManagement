using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Attachments.Commands
{
	public class DeleteAttachmentCommand:IRequest<Unit>
	{
		public int Id { get; set; }
		public DeleteAttachmentCommand(int id)
		{
			Id = id;
		}
	}
}
