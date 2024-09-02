using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Schedules.Commands
{
	public class DeleteScheduleCommand : IRequest<Unit>
	{
		public int Id { get; set; }
		public DeleteScheduleCommand(int id)
		{
			Id = id;
		}
	}
}
