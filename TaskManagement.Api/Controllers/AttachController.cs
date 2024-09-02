using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Attachments.Commands;
using TaskManagement.Application.Attachments.Queries;

namespace TaskManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AttachController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AttachController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/attachment/{id}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAttachmentById(int id)
		{
			var query = new GetAttachmentByIdQuery (id);
			var result = await _mediator.Send(query);
			return result != null ? Ok(result) : NotFound();
		}

		// GET: api/attachment
		[HttpGet]
		public async Task<IActionResult> GetAllAttachments()
		{
			var query = new GetAllAttachmentsQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		// POST: api/attachment
		[HttpPost]
		public async Task<IActionResult> CreateAttachment([FromBody] CreateAttachmentCommand command)
		{
			var result = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetAttachmentById), new { id = result.Id }, result);
		}

		// PUT: api/attachment/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAttachment(int id, [FromBody] UpdateAttachmentCommand command)
		{
			if (id != command.Id)
			{
				return BadRequest();
			}

			var result = await _mediator.Send(command);
			return Ok(result);
		}

		// DELETE: api/attachment/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAttachment(int id)
		{
			var command = new DeleteAttachmentCommand (id);
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
