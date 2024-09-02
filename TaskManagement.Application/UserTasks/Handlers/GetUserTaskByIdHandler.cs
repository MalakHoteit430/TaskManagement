using MediatR;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.UserTasks.Queries;
using TaskManagement.Application.Repositories;
using System.Threading.Tasks;

namespace TaskManagement.Application.UserTasks.Handlers
{
	
		public class GetUserTaskByIdHandler : IRequestHandler<GetUserTaskByIdQuery, UserTaskDto>
		{
			private readonly IUserTaskRepository _taskRepository;

			public GetUserTaskByIdHandler(IUserTaskRepository taskRepository)
			{
				_taskRepository = taskRepository;
			}

			public async Task<UserTaskDto> Handle(GetUserTaskByIdQuery request, CancellationToken cancellationToken)
			{
				var task = await _taskRepository.GetByIdAsync(request.Id);

			if (task == null)
			{
				throw new KeyNotFoundException($"Task with Id {request.Id} not found.");
			}
				return task.Adapt<UserTaskDto>();
			}
		}
}
