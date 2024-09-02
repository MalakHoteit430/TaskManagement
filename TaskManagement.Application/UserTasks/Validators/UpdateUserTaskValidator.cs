using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.UserTasks.Commands;

namespace TaskManagement.Application.UserTasks.Validators
{
	public class UpdateUserTaskValidator : AbstractValidator<UpdateUserTaskCommand>
	{
		public UpdateUserTaskValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty().WithMessage("Task ID is required.");

			RuleFor(x => x.Title)
				.NotEmpty().WithMessage("Title is required.")
				.Length(1, 100).WithMessage("Title must be between 1 and 100 characters.");

			RuleFor(x => x.Description)
				.MaximumLength(500).WithMessage("Description can be up to 500 characters.");

		}
		}
	}
