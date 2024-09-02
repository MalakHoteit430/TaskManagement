using MediatR;
using Mapster;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Users.Commands;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Users.Handlers
{
	public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDto>
	{
		private readonly UserManager<User> _userManager;

		public UpdateUserHandler(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByIdAsync(request.UserId);

			if (user == null)
			{
				throw new Exception("User not found");
			}

			user.UserName = request.UserName;
			user.Email = request.Email;

			var result = await _userManager.UpdateAsync(user);

			if (!result.Succeeded)
			{
				throw new Exception("User update failed");
			}

			return user.Adapt<UserDto>();
		}
	}
	}
