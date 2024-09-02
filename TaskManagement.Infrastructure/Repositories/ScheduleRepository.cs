using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Application.Repositories;
using TaskManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Infrastructure.Repositories
{
	public class ScheduleRepository : IScheduleRepository
	{
		private readonly TaskDbContext _context;

		public ScheduleRepository(TaskDbContext context)
		{
			_context = context;
		}

		public async Task<Schedule> GetByIdAsync(int id)
		{
			return await _context.Schedules
				
				.Include(t => t.UserTasks)
				.Include(t=>t.Projects)
				.FirstOrDefaultAsync(t => t.ScheduleId == id);
		}

		public async Task<IEnumerable<Schedule>> GetAllAsync()
		{
			return await _context.Schedules
				.Include(t => t.UserTasks)
				.Include(t => t.Projects)
				.ToListAsync();
		}

		public async Task AddAsync(Schedule schedule)
		{
			await _context.Schedules.AddAsync(schedule);
		}

		public async Task UpdateAsync(Schedule schedule)
		{
			_context.Schedules.Update(schedule);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Schedule schedule)
		{
			_context.Schedules.Remove(schedule);
			await _context.SaveChangesAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
