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
	public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDto>
	{
		private readonly UserManager<User> _userManager;

		public RegisterUserHandler(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
		{
			var user = new User
			{
				UserName = request.UserName,
				Email = request.Email
			};

			var result = await _userManager.CreateAsync(user, request.Password);

			if (!result.Succeeded)
			{
				throw new Exception("User registration failed");
			}

			return user.Adapt<UserDto>();
		}
	}
	}
