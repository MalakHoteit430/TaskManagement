using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.UserTasks.Queries;
using TaskManagement.Application.UserTasks.Commands;

namespace TaskManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserTaskController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UserTaskController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<UserTaskDto>> GetById(int id)
		{
			var result = await _mediator.Send(new GetUserTaskByIdQuery(id));
			return Ok(result);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserTaskDto>>> GetAll()
		{
			var result = await _mediator.Send(new GetAllUserTasksQuery());
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult> Create(CreateUserTaskCommand command)
		{
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Update(int id, UpdateUserTaskCommand command)
		{
			command.Id = id;
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			await _mediator.Send(new DeleteUserTaskCommand(id));
			return NoContent();
		}
	}
}
