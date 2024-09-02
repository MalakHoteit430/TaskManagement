using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Infrastructure.Repositories
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly TaskDbContext _context;

		public ReviewRepository(TaskDbContext context)
		{
			_context = context;
		}

		public async Task<Review> GetByIdAsync(int id)
		{
			return await _context.Reviews.FindAsync(id);
		}

		public async Task<IEnumerable<Review>> GetAllAsync()
		{
			return await _context.Reviews.ToListAsync();
		}

		public async Task AddAsync(Review review)
		{
			await _context.Reviews.AddAsync(review);
		}

		public async Task UpdateAsync(Review review)
		{
			_context.Reviews.Update(review);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Review review)
		{
			_context.Reviews.Remove(review);
			await _context.SaveChangesAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
