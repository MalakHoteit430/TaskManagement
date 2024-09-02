using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Reviews.Queries
{
	public class GetReviewByIdQuery : IRequest<ReviewDto>
	{
		public int Id { get; set; }
		public GetReviewByIdQuery(int id)
		{
			Id = id;
		}
	
	}
}
