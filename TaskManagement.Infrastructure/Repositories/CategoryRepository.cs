using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Application.Repositories;
using TaskManagement.Domain.Models;

namespace TaskManagement.Infrastructure.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly TaskDbContext _context;

		public CategoryRepository(TaskDbContext context)
		{
			_context = context;
		}

		public async Task<Category> GetByIdAsync(int id)
		{
			return await _context.Categories.FindAsync(id);
		}

		public async Task<IEnumerable<Category>> GetAllAsync()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task AddAsync(Category category)
		{
			await _context.Categories.AddAsync(category);
			
		}

		public async Task UpdateAsync(Category category)
		{
			_context.Categories.Update(category);
			await _context.SaveChangesAsync();
			
		}
		public async Task DeleteAsync(Category category)
		{
			_context.Categories.Remove(category);
			await _context.SaveChangesAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
