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


namespace TaskManagement.Application.Projects.Handlers
{
	public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ProjectDto>
	{
		private readonly IProjectRepository _projectRepository;

		public GetProjectByIdHandler(IProjectRepository projectRepository)
		{
			_projectRepository= projectRepository;
		}

		public async Task<ProjectDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
		{
			var project = await _projectRepository.GetByIdAsync(request.Id);

			if (project == null)
			{
				throw new KeyNotFoundException($"Project with Id {request.Id} not found.");
			}
			return project.Adapt<ProjectDto>();
		}
	}
}

