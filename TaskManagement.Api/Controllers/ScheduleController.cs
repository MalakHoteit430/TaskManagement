using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Schedules.Queries;
using TaskManagement.Application.Schedules.Commands;

namespace TaskManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ScheduleController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ScheduleController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/schedule/{id}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetScheduleById(int id)
		{
			var query = new GetScheduleByIdQuery (id);
			var result = await _mediator.Send(query);
			return result != null ? Ok(result) : NotFound();
		}

		// GET: api/schedule
		[HttpGet]
		public async Task<IActionResult> GetAllSchedules()
		{
			var query = new GetAllSchedulesQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		// POST: api/schedule
		[HttpPost]
		public async Task<IActionResult> CreateSchedule([FromBody] CreateScheduleCommand command)
		{
			var result = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetScheduleById), new { id = result.Id }, result);
		}

		// PUT: api/schedule/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSchedule(int id, [FromBody] UpdateScheduleCommand command)
		{
			if (id != command.Id)
			{
				return BadRequest();
			}

			var result = await _mediator.Send(command);
			return Ok(result);
		}

		// DELETE: api/schedule/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSchedule(int id)
		{
			var command = new DeleteScheduleCommand (id );
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
