using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Reviews.Commands;

namespace TaskManagement.Application.Reviews.Handlers
{
	public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, ReviewDto>
	{
		private readonly IReviewRepository _reviewRepository;

		public CreateReviewHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
			var review = new Domain.Models.Review
			{
				Rating = request.Rating,
				Comment = request.Comment,
				UserId = request.UserId,
			};

			await _reviewRepository.AddAsync(review);
			await _reviewRepository.SaveChangesAsync();

			return review.Adapt<ReviewDto>();
		}
	}
}