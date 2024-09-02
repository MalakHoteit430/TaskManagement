using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Users.Commands;

namespace TaskManagement.Application.Users.Validators
{
	public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
	{
		public RegisterUserValidator()
		{
			RuleFor(x => x.UserName)
				.NotEmpty().WithMessage("Username is required.")
				.Length(5, 20).WithMessage("Username must be between 5 and 20 characters.");

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email is required.")
				.EmailAddress().WithMessage("Invalid email format.");

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Password is required.")
				.Length(6, 100).WithMessage("Password must be between 6 and 100 characters.");
		}
	}
}
