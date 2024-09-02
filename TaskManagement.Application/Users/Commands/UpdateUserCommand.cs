using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Users.Commands
{
	public class UpdateUserCommand : IRequest<UserDto>
	{
		public string UserId { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
	}
}
