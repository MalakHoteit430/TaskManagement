using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Reviews.Commands;

namespace TaskManagement.Application.Reviews.Validators
{
	public class DeleteReviewValidator : AbstractValidator<DeleteReviewCommand>
	{
		public DeleteReviewValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty().WithMessage("Review ID is required.");
		}
	}
}
