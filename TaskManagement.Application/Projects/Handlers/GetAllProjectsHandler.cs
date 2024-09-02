using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Projects.Queries;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.UserTasks.Queries;

namespace TaskManagement.Application.Projects.Handlers
{
	public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<ProjectDto>>
	{
		private readonly IProjectRepository _projectRepository;

		public GetAllProjectsHandler(IProjectRepository projectRepository)
		{
			_projectRepository = projectRepository;
		}

		public async Task<IEnumerable<ProjectDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
		{
			var projects = await _projectRepository.GetAllAsync();
			return projects.Adapt<IEnumerable<ProjectDto>>();
		}
	}
}
