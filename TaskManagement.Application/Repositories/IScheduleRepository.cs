using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Repositories
{
	public interface IScheduleRepository
	{
		Task<Schedule> GetByIdAsync(int id);
		Task<IEnumerable<Schedule>> GetAllAsync();
		Task AddAsync(Schedule schedule);
		Task UpdateAsync(Schedule schedule);
		Task DeleteAsync(Schedule schedule);
		Task SaveChangesAsync();
	}
}
