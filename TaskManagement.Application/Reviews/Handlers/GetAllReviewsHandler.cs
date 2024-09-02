using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Reviews.Queries;
using Mapster;

namespace TaskManagement.Application.Reviews.Handlers
{
	public class GetAllReviewsHandler : IRequestHandler<GetAllReviewsQuery, IEnumerable<ReviewDto>>
	{
		private readonly IReviewRepository _reviewRepository;

		public GetAllReviewsHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<IEnumerable<ReviewDto>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
		{
			var reviews = await _reviewRepository.GetAllAsync();
			return reviews.Adapt<IEnumerable<ReviewDto>>();
		}	
	}
}
