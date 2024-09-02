using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Users.Commands;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Users.Handlers
{
	public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
	{
		private readonly SignInManager<User> _signInManager;

		public LoginUserHandler(SignInManager<User> signInManager)
		{
			_signInManager = signInManager;
		}

		public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
		{
			var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, lockoutOnFailure: true);

			if (!result.Succeeded)
			{
				throw new Exception("Invalid login attempt");
			}

			// Normally, you would generate a JWT or other authentication token here
			return "Authentication Token";
		}
	}
	}
