using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Users.Commands;

namespace TaskManagement.Application.Users.Validators
{
	public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
	{
		public UpdateUserValidator()
		{
			RuleFor(x => x.UserId)
				.NotEmpty().WithMessage("User ID is required.");

			RuleFor(x => x.UserName)
				.NotEmpty().WithMessage("Username is required.")
				.Length(5, 20).WithMessage("Username must be between 5 and 20 characters.");

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email is required.")
				.EmailAddress().WithMessage("Invalid email format.");

			
		}
	}
}
