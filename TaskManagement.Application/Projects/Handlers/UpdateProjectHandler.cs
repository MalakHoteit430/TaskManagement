using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Projects.Commands;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.UserTasks.Commands;

namespace TaskManagement.Application.Projects.Handlers
{
	public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, ProjectDto>
	{
		private readonly IProjectRepository _projectRepository;

		public UpdateProjectHandler(IProjectRepository projectRepository)
		{
			_projectRepository= projectRepository;
		}

		public async Task<ProjectDto> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
		{
			var project = await _projectRepository.GetByIdAsync(request.ProjectId);
			if (project == null) throw new KeyNotFoundException("Project not found");

			project.Name = request.Name;
			project.CategoryId= request.CategoryId;
			
			await _projectRepository.UpdateAsync(project);
			await _projectRepository.SaveChangesAsync();

			return project.Adapt<ProjectDto>();
		}
	}
}
