using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Categories.Queries
{
	public class GetCategoryByIdQuery : IRequest<CategoryDto>
	{
		public int Id { get; set; }
		public GetCategoryByIdQuery(int id)
		{
			Id = id;
		}
	
	}
}
