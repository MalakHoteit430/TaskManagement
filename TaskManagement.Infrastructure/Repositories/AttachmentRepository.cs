using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Infrastructure.Repositories
{
	public class AttachmentRepository : IAttachmentRepository
	{
		private readonly TaskDbContext _context;

		public AttachmentRepository(TaskDbContext context)
		{
			_context = context;
		}

		public async Task<Attach> GetByIdAsync(int id)
		{
			return await _context.Attachments.FindAsync(id);
		}

		public async Task<IEnumerable<Attach>> GetAllAsync()
		{
			return await _context.Attachments.ToListAsync();
		}

		public async Task AddAsync(Attach attachment)
		{
			await _context.Attachments.AddAsync(attachment);
		}

		public async Task UpdateAsync(Attach attachment)
		{
			 _context.Attachments.Update(attachment);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Attach attachment)
		{
			_context.Attachments.Remove(attachment);
			await _context.SaveChangesAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
