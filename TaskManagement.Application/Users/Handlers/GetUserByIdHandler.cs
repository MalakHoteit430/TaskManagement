using MediatR;
using Mapster;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Users.Queries;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Users.Handlers
{
	public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
	{
		private readonly UserManager<User> _userManager;

		public GetUserByIdHandler(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByIdAsync(request.UserId);

			if (user == null)
			{
				throw new Exception("User not found");
			}

			return user.Adapt<UserDto>();
		}
	}
	}
