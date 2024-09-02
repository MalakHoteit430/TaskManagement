using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;
using TaskManagement.Application.Repositories;
using TaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Infrastructure.Repositories
{
	public class UserTaskRepository:IUserTaskRepository
	{
		private readonly TaskDbContext _context;

		public UserTaskRepository(TaskDbContext context)
		{
			_context = context;
		}

		public async Task<UserTask> GetByIdAsync(int id)
		{
			return await _context.UserTasks
				.Include(t=>t.Category)
				.Include(t => t.Attachments)
				.FirstOrDefaultAsync(t => t.UserTaskId == id);
		}

		public async Task<IEnumerable<UserTask>> GetAllAsync()
		{
			return await _context.UserTasks
				.Include(t => t.Category)
				.Include(t => t.Attachments)
				
				.ToListAsync();
		}

		public async Task AddAsync(UserTask userTask)
		{
			await _context.UserTasks.AddAsync(userTask);
		}

		public async Task UpdateAsync(UserTask userTask)
		{
			_context.UserTasks.Update(userTask);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(UserTask userTask)
		{
			_context.UserTasks.Remove(userTask);
			await _context.SaveChangesAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
