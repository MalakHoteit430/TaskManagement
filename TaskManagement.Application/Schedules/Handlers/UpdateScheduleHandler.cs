using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Schedules.Commands;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Schedules.Handlers
{
	public class UpdateScheduleHandler : IRequestHandler<UpdateScheduleCommand, ScheduleDto>
	{
		private readonly IScheduleRepository _scheduleRepository;

		public UpdateScheduleHandler(IScheduleRepository scheduleRepository)
		{
			_scheduleRepository = scheduleRepository;
		}

		public async Task<ScheduleDto> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
		{
			var schedule = await _scheduleRepository.GetByIdAsync(request.Id);

			if (schedule == null)
			{
				throw new KeyNotFoundException("Schedule not found!");
			}

			schedule.DayOfWeek = request.DayOfWeek;
			schedule.UserTasks = request.UserTasks;
			schedule.Projects = request.Projects;

			await _scheduleRepository.SaveChangesAsync();

			return schedule.Adapt<ScheduleDto>();
		}
	}
}
