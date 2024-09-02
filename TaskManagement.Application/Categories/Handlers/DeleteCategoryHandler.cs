using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Categories.Commands;
using TaskManagement.Application.Repositories;

namespace TaskManagement.Application.Categories.Handlers
{
	public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Unit>
	{
		private readonly ICategoryRepository _categoryRepository;

		public DeleteCategoryHandler(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<Unit> Handle(DeleteCategoryCommand request,CancellationToken cancellationToken)
		{
			var category = await _categoryRepository.GetByIdAsync(request.Id);

			if (category == null)
			{
				throw new KeyNotFoundException("Category not found!");
			}

			await _categoryRepository.DeleteAsync(category);

			return Unit.Value;
		}
	}
}
