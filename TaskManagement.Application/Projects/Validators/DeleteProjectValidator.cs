using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Projects.Commands;

namespace TaskManagement.Application.Projects.Validators
{
	public class DeleteProjectValidator : AbstractValidator<DeleteProjectCommand>
	{
		public DeleteProjectValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty().WithMessage("Project ID is required.");
		}
	}
}
