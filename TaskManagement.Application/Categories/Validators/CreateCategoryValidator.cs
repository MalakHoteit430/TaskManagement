using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Categories.Commands;

namespace TaskManagement.Application.Categories.Validators
{
	public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
	{
		public CreateCategoryValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required.")
				.Length(1, 50).WithMessage("Name must be between 1 and 50 characters.");
		}
	}
}
