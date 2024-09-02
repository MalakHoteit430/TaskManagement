using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Categories.Commands;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Categories.Handlers
{
	public class UpdateCategoryHandler: IRequestHandler<UpdateCategoryCommand, CategoryDto>
	{
		private readonly ICategoryRepository _categoryRepository;

		public UpdateCategoryHandler(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
		{
			var category= await _categoryRepository.GetByIdAsync(request.Id);

			if (category == null)
			{
				throw new KeyNotFoundException("Category not found!");
			}

			category.Name=request.Name;

			await _categoryRepository.SaveChangesAsync();

			return category.Adapt<CategoryDto>();
		}
	}
}
