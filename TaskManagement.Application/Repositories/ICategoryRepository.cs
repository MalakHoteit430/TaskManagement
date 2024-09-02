using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Repositories
{
	public interface ICategoryRepository
	{
		Task<Category> GetByIdAsync(int id);
		Task<IEnumerable<Category>> GetAllAsync();
		Task AddAsync(Category category);
		Task UpdateAsync(Category category);
		Task DeleteAsync(Category category);
		Task SaveChangesAsync();
	}
}
