using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Schedules.Queries;
using TaskManagement.Domain.Models;
using Mapster;

namespace TaskManagement.Application.Schedules.Handlers
{
	public class GetScheduleByIdHandler : IRequestHandler<GetScheduleByIdQuery, ScheduleDto>
	{
		private readonly IScheduleRepository _scheduleRepository;

		public GetScheduleByIdHandler(IScheduleRepository scheduleRepository)
		{
			_scheduleRepository = scheduleRepository;
		}

		public async Task<ScheduleDto> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
		{
			var schedule=await _scheduleRepository.GetByIdAsync(request.Id);

			if (schedule == null)
			{
				throw new KeyNotFoundException("Schedule not found!");
			}
			return schedule.Adapt<ScheduleDto>();
		}
	}
}
