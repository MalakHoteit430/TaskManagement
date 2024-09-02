using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Reviews.Commands;
using TaskManagement.Application.Repositories;

namespace TaskManagement.Application.Reviews.Handlers
{
	public class DeleteReviewHandler : IRequestHandler<DeleteReviewCommand, Unit>
	{
		private readonly IReviewRepository _reviewRepository;

		public DeleteReviewHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<Unit> Handle(DeleteReviewCommand request,CancellationToken cancellationToken)
		{
			var review = await _reviewRepository.GetByIdAsync(request.Id);

			if (review == null)
			{
				throw new KeyNotFoundException("Review not found!");
			}

			await _reviewRepository.DeleteAsync(review);

			return Unit.Value;
		}
	}
}
