using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application;
using Mapster;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.UserTasks.Queries;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.UserTasks.Handlers
{
	public class GetAllUserTasksHandler : IRequestHandler<GetAllUserTasksQuery, IEnumerable<UserTaskDto>>
	{
		private readonly IUserTaskRepository _taskRepository;

		public GetAllUserTasksHandler(IUserTaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

		public async Task<IEnumerable<UserTaskDto>> Handle(GetAllUserTasksQuery request, CancellationToken cancellationToken)
		{
			var tasks = await _taskRepository.GetAllAsync();
			return tasks.Adapt<IEnumerable<UserTaskDto>>();
		}
	}
}
