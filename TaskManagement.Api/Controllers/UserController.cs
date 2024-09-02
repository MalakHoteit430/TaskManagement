using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Users.Commands;
using TaskManagement.Application.Users.Queries;

namespace TaskManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UserController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/user/{id}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetUserById(string id)
		{
			var query = new GetUserByIdQuery { UserId = id };
			var result = await _mediator.Send(query);
			return result != null ? Ok(result) : NotFound();
		}

		// PUT: api/user/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserCommand command)
		{
			if (id != command.UserId)
			{
				return BadRequest();
			}

			var result = await _mediator.Send(command);
			return Ok(result);
		}

		// DELETE: api/user/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(string id)
		{
			var command = new DeleteUserCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
