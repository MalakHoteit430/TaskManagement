using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Projects.Commands
{
	public class UpdateProjectCommand : IRequest<ProjectDto>
	{

		public int ProjectId { get; set; }


		public string Name { get; set; }
		public int CategoryId { get; set; }
		public ICollection<int> UserTaskId { get; set; }
	}
}
