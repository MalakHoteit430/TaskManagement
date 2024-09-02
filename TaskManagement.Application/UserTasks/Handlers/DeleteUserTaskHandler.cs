using MediatR;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.UserTasks.Commands;
using TaskManagement.Domain.Models;
using TaskManagement.Application.Repositories;

namespace TaskManagement.Application.UserTasks.Handlers
{
	public class DeleteUserTaskHandler : IRequestHandler<DeleteUserTaskCommand,Unit>
	{
		private readonly IUserTaskRepository _taskRepository;

		public DeleteUserTaskHandler(IUserTaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

		public async Task<Unit> Handle(DeleteUserTaskCommand request, CancellationToken cancellationToken)
		{
			var task = await _taskRepository.GetByIdAsync(request.Id);

			if (task == null)
			{
				throw new KeyNotFoundException($"Task with ID {request.Id} not found.");
			}
			await _taskRepository.DeleteAsync(task);
			//await _taskRepository.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
