using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Repositories
{
	public interface IUserTaskRepository
	{
		Task<UserTask> GetByIdAsync (int id);
		Task<IEnumerable<UserTask>> GetAllAsync ();
		Task AddAsync(UserTask userTask);
		Task UpdateAsync(UserTask userTask);
		Task DeleteAsync(UserTask userTask);
		Task SaveChangesAsync();
	}
}
