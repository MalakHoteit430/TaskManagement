using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Schedules.Queries
{
	public class GetAllSchedulesQuery : IRequest<IEnumerable<ScheduleDto>>
	{
	}
}
