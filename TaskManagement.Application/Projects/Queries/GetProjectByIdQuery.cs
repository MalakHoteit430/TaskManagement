using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Projects.Queries
{
	public class GetProjectByIdQuery : IRequest<ProjectDto>
	{
		public int Id { get; set; }
		public GetProjectByIdQuery(int id)
		{
			Id = id;
		}

	}
}
