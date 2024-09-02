using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Users.Commands
{
	public class LoginUserCommand : IRequest<string>
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
