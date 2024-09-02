using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Categories.Queries;
using Mapster;

namespace TaskManagement.Application.Categories.Handlers
{
	public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
	{
		private readonly ICategoryRepository _categoryRepository;

		public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
		{
			var categories = await _categoryRepository.GetAllAsync();
			return categories.Adapt<IEnumerable<CategoryDto>>();
		}	
	}
}
