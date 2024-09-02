using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Reviews.Queries;
using TaskManagement.Application.Reviews.Commands;

namespace TaskManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ReviewController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/review/{id}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetReviewById(int id)
		{
			var query = new GetReviewByIdQuery(id);
			var result = await _mediator.Send(query);
			return result != null ? Ok(result) : NotFound();
		}

		// GET: api/review
		[HttpGet]
		public async Task<IActionResult> GetAllReviews()
		{
			var query = new GetAllReviewsQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		// POST: api/review
		[HttpPost]
		public async Task<IActionResult> CreateReview([FromBody] CreateReviewCommand command)
		{
			var result = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetReviewById), new { id = result.Id }, result);
		}

		// PUT: api/review/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateReview(int id, [FromBody] UpdateReviewCommand command)
		{
			if (id != command.Id)
			{
				return BadRequest();
			}

			var result = await _mediator.Send(command);
			return Ok(result);
		}

		// DELETE: api/review/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteReview(int id)
		{
			var command = new DeleteReviewCommand (id);
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
