using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Schedules.Commands
{
	public class UpdateScheduleCommand : IRequest<ScheduleDto>
	{
		public int Id { get; set; }
		public DayOfWeek DayOfWeek { get; set; }

		public ICollection<UserTask> UserTasks { get; set; }
		public ICollection<Project> Projects { get; set; }
	}
}
