﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Users.Commands;

namespace TaskManagement.Application.Users.Handlers
{
	public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
	{
		private readonly IUserRepository _userRepository;

		public DeleteUserCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			await _userRepository.DeleteAsync(request.Id);
			return Unit.Value;
		}
	}
}
