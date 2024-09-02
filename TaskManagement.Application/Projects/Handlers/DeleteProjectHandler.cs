using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Projects.Commands;
using TaskManagement.Application.Repositories;


namespace TaskManagement.Application.Projects.Handlers
{
	public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, Unit>
	{
		private readonly IProjectRepository _projectRepository;

		public DeleteProjectHandler(IProjectRepository projectRepository)
		{
			_projectRepository = projectRepository;
		}

		public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
		{
			var project = await _projectRepository.GetByIdAsync(request.Id);

			if (project == null)
			{
				throw new KeyNotFoundException($"Project with ID {request.Id} not found.");
			}
			await _projectRepository.SaveChangesAsync();

			return Unit.Value;
		}
	
	}
}
