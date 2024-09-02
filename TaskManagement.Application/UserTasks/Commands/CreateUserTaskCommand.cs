using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.UserTasks.Commands
{
	public class CreateUserTaskCommand : IRequest<UserTaskDto>
	{
		public string Title { get; set; }
		public string Description { get; set; }
		
		
		public int CategoryId { get; set; }
		public ICollection<int> AttachmentId {  get; set; }
	
	}
}
