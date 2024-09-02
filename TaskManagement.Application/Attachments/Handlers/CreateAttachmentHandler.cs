using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Attachments.Commands;

namespace TaskManagement.Application.Attachments.Handlers
{
	public class CreateAttachmentHandler : IRequestHandler<CreateAttachmentCommand, AttachmentDto>
	{
		private readonly IAttachmentRepository _attachmentRepository;

		public CreateAttachmentHandler(IAttachmentRepository attachmentRepository)
		{
			_attachmentRepository = attachmentRepository;
		}

		public async Task<AttachmentDto> Handle(CreateAttachmentCommand request, CancellationToken cancellationToken)
		{
			var attachment = new Domain.Models.Attach
			{
				FileName= request.FileName,
				FilePath= request.FilePath,
				

			};

			await _attachmentRepository.AddAsync(attachment);
			await _attachmentRepository.SaveChangesAsync();

			return attachment.Adapt<AttachmentDto>();
		}
	}
}