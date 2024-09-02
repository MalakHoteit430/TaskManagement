using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Users.Commands;

namespace TaskManagement.Application.Users.Validators
{
	public class LoginUserValidator : AbstractValidator<LoginUserCommand>
	{
		public LoginUserValidator()
		{
			RuleFor(x => x.UserName)
				.NotEmpty().WithMessage("Username is required.");
				

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Password is required.");
		}
	}
}
