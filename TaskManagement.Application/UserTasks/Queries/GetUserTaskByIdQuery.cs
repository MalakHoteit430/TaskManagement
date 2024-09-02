using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.UserTasks.Queries
{
	public class GetUserTaskByIdQuery:IRequest<UserTaskDto>
	{
		public int Id { get; set; }
		public GetUserTaskByIdQuery(int id) { 
		Id= id;
		}
	}
}
