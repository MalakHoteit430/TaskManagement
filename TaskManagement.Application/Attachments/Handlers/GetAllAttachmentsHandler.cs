using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Attachments.Queries;
using Mapster;

namespace TaskManagement.Application.Attachments.Handlers
{
	public class GetAllAttachmentsHandler : IRequestHandler<GetAllAttachmentsQuery, IEnumerable<AttachmentDto>>
	{
		private readonly IAttachmentRepository _attachmentRepository;

		public GetAllAttachmentsHandler(IAttachmentRepository attachmentRepository)
		{
			_attachmentRepository = attachmentRepository;
		}

		public async Task<IEnumerable<AttachmentDto>> Handle(GetAllAttachmentsQuery request, CancellationToken cancellationToken)
		{
			var attachments = await _attachmentRepository.GetAllAsync();
			return attachments.Adapt<IEnumerable<AttachmentDto>>();
		}	
	}
}
