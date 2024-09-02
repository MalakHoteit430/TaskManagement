using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Users.Commands
{
	public class RegisterUserCommand : IRequest<UserDto>
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
