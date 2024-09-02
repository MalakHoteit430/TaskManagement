using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Users.Commands;

namespace TaskManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// POST: api/auth/register
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
		{
			var result = await _mediator.Send(command);
			return CreatedAtAction(nameof(Register), new { id = result.Id }, result);
		}

		// POST: api/auth/login
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
