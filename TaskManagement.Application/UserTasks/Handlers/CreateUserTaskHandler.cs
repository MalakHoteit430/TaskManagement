using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.UserTasks.Commands;
using TaskManagement.Application.Repositories;
using Mapster;

namespace TaskManagement.Application.UserTasks.Handlers
{
	public class CreateUserTaskHandler : IRequestHandler<CreateUserTaskCommand, UserTaskDto>
	{
		private readonly IUserTaskRepository _taskRepository;

		public CreateUserTaskHandler(IUserTaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

		public async Task<UserTaskDto> Handle(CreateUserTaskCommand request, CancellationToken cancellationToken)
		{
			var task = new Domain.Models.UserTask
			{
				Title = request.Title,
				Description = request.Description,
				
				
				CategoryId= request.CategoryId
			};

			await _taskRepository.AddAsync(task);
			await _taskRepository.SaveChangesAsync();

			return task.Adapt<UserTaskDto>();
		}
	}
}
