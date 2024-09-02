using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Categories.Commands;
using TaskManagement.Application.Categories.Queries;

namespace TaskManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CategoryController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/category/{id}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategoryById(int id)
		{
			var query = new GetCategoryByIdQuery(id);
			var result = await _mediator.Send(query);
			return result != null ? Ok(result) : NotFound();
		}

		// GET: api/category
		[HttpGet]
		public async Task<IActionResult> GetAllCategories()
		{
			var query = new GetAllCategoriesQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		// POST: api/category
		[HttpPost]
		public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
		{
			var result = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetCategoryById), new { id = result.Id }, result);
		}

		// PUT: api/category/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryCommand command)
		{
			if (id != command.Id)
			{
				return BadRequest();
			}

			var result = await _mediator.Send(command);
			return Ok(result);
		}

		// DELETE: api/category/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			var command = new DeleteCategoryCommand (id);
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
