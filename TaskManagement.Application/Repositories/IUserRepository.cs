using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Repositories
{
	public interface IUserRepository
	{
		Task<User> GetByIdAsync(string id);
		Task<IEnumerable<User>> GetAllAsync();
		Task AddAsync(User user);
		Task UpdateAsync(User user);
		
		Task SaveChangesAsync();
		Task DeleteAsync(string id);
	}
}
