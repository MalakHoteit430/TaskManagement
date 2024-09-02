using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.UserTasks.Commands;

namespace TaskManagement.Application.UserTasks.Validators
{
	public class DeleteUserTaskValidator : AbstractValidator<DeleteUserTaskCommand>
	{
		public DeleteUserTaskValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty().WithMessage("Task ID is required.");
		}
	}
	}
