using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Projects.Commands;

namespace TaskManagement.Application.Projects.Validators
{
	public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
	{
		public CreateProjectValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required.")
				.Length(1, 100).WithMessage("Name must be between 1 and 100 characters.");


		}
	}
}
