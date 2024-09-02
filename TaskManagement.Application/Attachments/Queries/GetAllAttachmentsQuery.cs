using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Attachments.Queries
{
	public class GetAllAttachmentsQuery : IRequest<IEnumerable<AttachmentDto>>
	{
	}
}
