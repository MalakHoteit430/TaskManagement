using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Schedules.Commands;

namespace TaskManagement.Application.Schedules.Validators
{
	public class CreateScheduleValidator : AbstractValidator<CreateScheduleCommand>
	{
		public CreateScheduleValidator()
		{
			
			RuleFor(x => x.UserTasks)
				.NotEmpty().WithMessage("At least one task is required.");
		}
	}
}
