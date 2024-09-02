using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Attachments.Queries;
using TaskManagement.Domain.Models;
using Mapster;

namespace TaskManagement.Application.Attachments.Handlers
{
	public class GetAttachmentByIdHandler : IRequestHandler<GetAttachmentByIdQuery, AttachmentDto>
	{
		private readonly IAttachmentRepository _attachmentRepository;

		public GetAttachmentByIdHandler(IAttachmentRepository attachmentRepository)
		{
			_attachmentRepository = attachmentRepository;
		}

		public async Task<AttachmentDto> Handle(GetAttachmentByIdQuery request, CancellationToken cancellationToken)
		{
			var attachment= await _attachmentRepository.GetByIdAsync(request.Id);

			if (attachment == null)
			{
				throw new KeyNotFoundException("Attachment not found!");
			}
			return attachment.Adapt<AttachmentDto>();
		}
	}
}
