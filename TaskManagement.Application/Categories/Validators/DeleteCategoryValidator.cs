using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Categories.Commands;

namespace TaskManagement.Application.Categories.Validators
{
	public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
	{
		public DeleteCategoryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty().WithMessage("Category ID is required.");
		}
	}
}