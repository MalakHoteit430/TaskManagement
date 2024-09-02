using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Repositories
{
	public interface IAttachmentRepository
	{
		Task<Attach> GetByIdAsync(int id);
		Task<IEnumerable<Attach>> GetAllAsync();
		Task AddAsync(Attach attachment);
		Task UpdateAsync(Attach attachment);
		Task DeleteAsync(Attach attachment);
		Task SaveChangesAsync();
	}
}
