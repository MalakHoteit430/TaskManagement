using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.UserTasks.Commands
{
	public class DeleteUserTaskCommand : IRequest<Unit>
	{
		public int Id { get; set; }

		public DeleteUserTaskCommand(int id)
		{
			Id = id;
		}

	}
}
