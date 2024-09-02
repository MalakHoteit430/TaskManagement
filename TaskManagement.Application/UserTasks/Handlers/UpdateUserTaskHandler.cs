using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.UserTasks.Commands;

namespace TaskManagement.Application.UserTasks.Handlers
{
	public class UpdateUserTaskHandler : IRequestHandler<UpdateUserTaskCommand, UserTaskDto>
	{
		private readonly IUserTaskRepository _taskRepository;

		public UpdateUserTaskHandler(IUserTaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

		public async Task<UserTaskDto> Handle(UpdateUserTaskCommand request, CancellationToken cancellationToken)
		{
			var task = await _taskRepository.GetByIdAsync(request.Id);
			if (task == null) throw new KeyNotFoundException("Task not found");

			task.Title = request.Title;
			task.Description = request.Description;
			
			task.ProjectId = request.ProjectId;
			task.CategoryId = request.CategoryId;

			await _taskRepository.UpdateAsync(task);
			await _taskRepository.SaveChangesAsync();

			return task.Adapt<UserTaskDto>();
		}
	}
}
