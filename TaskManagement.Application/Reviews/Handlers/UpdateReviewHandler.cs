using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Reviews.Commands;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Reviews.Handlers
{
	public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, ReviewDto>
	{
		private readonly IReviewRepository _reviewRepository;

		public UpdateReviewHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<ReviewDto> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var review = await _reviewRepository.GetByIdAsync(request.Id);

			if (review == null)
			{
				throw new KeyNotFoundException("Review not found!");
			}

			review.Comment = request.Comment;
			review.UserId = request.UserId;

			await _reviewRepository.SaveChangesAsync();

			return review.Adapt<ReviewDto>();
		}
	}
}
