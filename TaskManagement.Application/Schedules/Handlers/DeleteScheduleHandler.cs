using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Schedules.Commands;
using TaskManagement.Application.Repositories;

namespace TaskManagement.Application.Schedules.Handlers
{
	public class DeleteScheduleHandler : IRequestHandler<DeleteScheduleCommand, Unit>
	{
		private readonly IScheduleRepository _scheduleRepository;

		public DeleteScheduleHandler(IScheduleRepository scheduleRepository)
		{
			_scheduleRepository = scheduleRepository;
		}

		public async Task<Unit> Handle(DeleteScheduleCommand request,CancellationToken cancellationToken)
		{
			var schedule = await _scheduleRepository.GetByIdAsync(request.Id);

			if (schedule == null)
			{
				throw new KeyNotFoundException("Schedule not found!");
			}

			await _scheduleRepository.DeleteAsync(schedule);

			return Unit.Value;
		}
	}
}
