using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Attachments.Commands;
using TaskManagement.Application.Repositories;

namespace TaskManagement.Application.Attachments.Handlers
{
	public class DeleteAttachmentHandler:IRequestHandler<DeleteAttachmentCommand,Unit>
	{
		private readonly IAttachmentRepository _attachmentRepository;

		public DeleteAttachmentHandler(IAttachmentRepository attachmentRepository)
		{
			_attachmentRepository = attachmentRepository;
		}

		public async Task<Unit> Handle(DeleteAttachmentCommand request,CancellationToken cancellationToken)
		{
			var attachment = await _attachmentRepository.GetByIdAsync(request.Id);

			if (attachment == null)
			{
				throw new KeyNotFoundException("Attachment not found!");
			}

			await _attachmentRepository.DeleteAsync(attachment);

			return Unit.Value;
		}
	}
}
