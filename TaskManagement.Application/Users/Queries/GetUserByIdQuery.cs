using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Users.Queries
{
	public class GetUserByIdQuery : IRequest<UserDto>
	{
		public string UserId { get; set; }
	}
}
