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
	public class ProjectRepository : IProjectRepository
	{
		private readonly TaskDbContext _context;
		public ProjectRepository(TaskDbContext context)
	{
		_context = context;
	}

	public async Task<Project> GetByIdAsync(int id)
	{
			return await _context.Projects.Include(p => p.UserTasks).SingleOrDefaultAsync(p => p.CategoryId == id);
	}

	public async Task<IEnumerable<Project>> GetAllAsync()
	{
		return await _context.Projects.Include(p=>p.UserTasks).ToListAsync();
	}

	public async Task AddAsync(Project project)
	{
		await _context.Projects.AddAsync(project);
	}

	public async Task UpdateAsync(Project project)
	{
		_context.Projects.Update(project);
			await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Project project)
	{
		_context.Projects.Remove(project);
			await _context.SaveChangesAsync();
	}

	public async Task SaveChangesAsync()
	{
		await _context.SaveChangesAsync();
	}
}
}
