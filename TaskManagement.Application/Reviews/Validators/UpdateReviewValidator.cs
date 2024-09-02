using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Reviews.Commands;

namespace TaskManagement.Application.Reviews.Validators
{
	public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
	{
		public UpdateReviewValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty().WithMessage("Review ID is required.");

			RuleFor(x => x.Comment)
				.NotEmpty().WithMessage("Content is required.")
				.MaximumLength(1000).WithMessage("Content can be up to 1000 characters.");

			RuleFor(x => x.Rating)
				.InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

		}
	}
}
