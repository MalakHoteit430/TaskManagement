using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Repositories;
using TaskManagement.Application.Categories.Commands;

namespace TaskManagement.Application.Categories.Handlers
{
	public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
	{
		private readonly ICategoryRepository _categoryRepository;

		public CreateCategoryHandler(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = new Domain.Models.Category
			{
				Name = request.Name,

			};

			await _categoryRepository.AddAsync(category);
			await _categoryRepository.SaveChangesAsync();

			return category.Adapt<CategoryDto>();
		}
	}
}