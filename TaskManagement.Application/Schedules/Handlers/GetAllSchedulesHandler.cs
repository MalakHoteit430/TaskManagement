using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Schedules.Queries;
using Mapster;

namespace TaskManagement.Application.Schedules.Handlers
{
	public class GetAllSchedulesHandler : IRequestHandler<GetAllSchedulesQuery, IEnumerable<ScheduleDto>>
	{
		private readonly IScheduleRepository _scheduleRepository;

		public GetAllSchedulesHandler(IScheduleRepository scheduleRepository)
		{
			_scheduleRepository = scheduleRepository;
		}

		public async Task<IEnumerable<ScheduleDto>> Handle(GetAllSchedulesQuery request, CancellationToken cancellationToken)
		{
			var schedules = await _scheduleRepository.GetAllAsync();
			return schedules.Adapt<IEnumerable<ScheduleDto>>();
		}	
	}
}
