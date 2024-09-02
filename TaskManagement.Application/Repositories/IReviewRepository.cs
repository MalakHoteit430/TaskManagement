using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Repositories
{
	public interface IReviewRepository
	{
		Task<Review> GetByIdAsync(int id);
		Task<IEnumerable<Review>> GetAllAsync();
		Task AddAsync(Review review);
		Task UpdateAsync(Review review);
		Task DeleteAsync(Review review);
		Task SaveChangesAsync();
	}
}
