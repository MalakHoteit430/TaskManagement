using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Reviews.Commands
{
	public class UpdateReviewCommand : IRequest<ReviewDto>
	{
		public int Id { get; set; }
		public int Rating { get; set; }

		public string Comment { get; set; }
		public DateTime CreationDate { get; set; }

		public string UserId { get; set; }
	}
}
