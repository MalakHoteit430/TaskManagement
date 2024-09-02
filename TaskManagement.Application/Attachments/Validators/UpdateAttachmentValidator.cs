using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Attachments.Commands;

namespace TaskManagement.Application.Attachments.Validators
{
	public class UpdateAttachmentValidator : AbstractValidator<UpdateAttachmentCommand>
	{
		public UpdateAttachmentValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty().WithMessage("Attachment ID is required.");

			RuleFor(x => x.FileName)
				.NotEmpty().WithMessage("File name is required.");

			RuleFor(x => x.FileName)
				.NotEmpty().WithMessage("File name is required.");

			RuleFor(x => x.FilePath)
				.NotEmpty().WithMessage("File path is required.");
		}
	}
}
