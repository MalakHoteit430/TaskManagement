using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Projects.Commands;

namespace TaskManagement.Application.Projects.Handlers
{
	public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, ProjectDto>
	{
		private readonly IProjectRepository _projectRepository;

		public CreateProjectHandler(IProjectRepository projectRepository)
		{
			_projectRepository = projectRepository;
		}

		public async Task<ProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
		{
			var project = new Domain.Models.Project
			{
				Name=request.Name,
			
				CategoryId = request.CategoryId,

			};

			await _projectRepository.AddAsync(project);
			await _projectRepository.SaveChangesAsync();

			return project.Adapt<ProjectDto>();
		}
	}
}
