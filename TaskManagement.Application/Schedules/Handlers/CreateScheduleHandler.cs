using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Schedules.Commands;

namespace TaskManagement.Application.Schedules.Handlers
{
	public class CreateScheduleHandler : IRequestHandler<CreateScheduleCommand, ScheduleDto>
	{
		private readonly IScheduleRepository _scheduleRepository;

		public CreateScheduleHandler(IScheduleRepository scheduleRepository)
		{
			_scheduleRepository = scheduleRepository;
		}

		public async Task<ScheduleDto> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
		{
			var schedule = new Domain.Models.Schedule
			{
				DayOfWeek = request.DayOfWeek,
			UserTasks=request.UserTasks,
			Projects=request.Projects

			};

			await _scheduleRepository.AddAsync(schedule);
			await _scheduleRepository.SaveChangesAsync();

			return schedule.Adapt<ScheduleDto>();
		}
	}
}