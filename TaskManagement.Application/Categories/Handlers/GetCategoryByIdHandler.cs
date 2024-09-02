using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Categories.Queries;
using TaskManagement.Domain.Models;
using Mapster;

namespace TaskManagement.Application.Categories.Handlers
{
	public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
	{
		private readonly ICategoryRepository _categoryRepository;

		public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
		{
			var category = await _categoryRepository.GetByIdAsync(request.Id);

			if (category == null)
			{
				throw new KeyNotFoundException("Category not found!");
			}
			return category.Adapt<CategoryDto>();
		}
	}
}
