using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Projects.Commands;
using TaskManagement.Application.Projects.Queries;

namespace TaskManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProjectController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/project/{id}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProjectById(int id)
		{
			var query = new GetProjectByIdQuery (id );
			var result = await _mediator.Send(query);
			return result != null ? Ok(result) : NotFound();
		}

		// GET: api/project
		[HttpGet]
		public async Task<IActionResult> GetAllProjects()
		{
			var query = new GetAllProjectsQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		// POST: api/project
		[HttpPost]
		public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand command)
		{
			var result = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetProjectById), new { id = result.Id }, result);
		}

		// PUT: api/project/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProject(int id, [FromBody] UpdateProjectCommand command)
		{
			if (id != command.ProjectId)
			{
				return BadRequest();
			}

			var result = await _mediator.Send(command);
			return Ok(result);
		}

		// DELETE: api/project/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProject(int id)
		{
			var command = new DeleteProjectCommand (id) ;
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
