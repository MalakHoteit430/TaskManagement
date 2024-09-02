using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Reviews.Queries;
using TaskManagement.Domain.Models;
using Mapster;

namespace TaskManagement.Application.Reviews.Handlers
{
	public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, ReviewDto>
	{
		private readonly IReviewRepository _reviewRepository;

		public GetReviewByIdHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<ReviewDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
		{
			var review = await _reviewRepository.GetByIdAsync(request.Id);

			if (review == null)
			{
				throw new KeyNotFoundException("Review not found!");
			}
			return review.Adapt<ReviewDto>();
		}
	}
}
