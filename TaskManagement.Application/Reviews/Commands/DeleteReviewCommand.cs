using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Reviews.Commands
{
	public class DeleteReviewCommand : IRequest<Unit>
	{
		public int Id { get; set; }
		public DeleteReviewCommand(int id)
		{
			Id = id;
		}
	}
}
