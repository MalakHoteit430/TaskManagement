using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Attachments.Commands;

namespace TaskManagement.Application.Attachments.Validators
{
	public class DeleteAttachmentValidator : AbstractValidator<DeleteAttachmentCommand>
	{
		public DeleteAttachmentValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty().WithMessage("Attachment ID is required.");
		}
	}
}
