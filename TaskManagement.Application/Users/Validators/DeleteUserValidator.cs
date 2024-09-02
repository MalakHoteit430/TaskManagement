using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Users.Commands;

namespace TaskManagement.Application.Users.Validators
{
	public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
	{
		public DeleteUserValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty().WithMessage("User ID is required.");
		}
	}
}
