using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Attachments.Commands;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Attachments.Handlers
{
	public class UpdateAttachmentHandler: IRequestHandler<UpdateAttachmentCommand, AttachmentDto>
	{
		private readonly IAttachmentRepository _attachmentRepository;

		public UpdateAttachmentHandler(IAttachmentRepository attachmentRepository)
		{
			_attachmentRepository = attachmentRepository;
		}

		public async Task<AttachmentDto> Handle(UpdateAttachmentCommand request, CancellationToken cancellationToken)
		{
			var attachment = await _attachmentRepository.GetByIdAsync(request.Id);

			if (attachment == null)
			{
				throw new KeyNotFoundException("Attachment not found!");
			}

			attachment.FilePath= request.FilePath;
			attachment.FileName= request.FileName;

			await _attachmentRepository.SaveChangesAsync();

			return attachment.Adapt<AttachmentDto>();
		}
	}
}
