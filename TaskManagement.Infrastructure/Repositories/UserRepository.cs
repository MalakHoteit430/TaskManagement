using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories;
using TaskManagement.Domain.Models;

namespace TaskManagement.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly UserManager<User> _userManager;

		public UserRepository(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public async Task<User> GetByIdAsync(string id)
		{
			return await _userManager.FindByIdAsync(id);
		}

		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await _userManager.Users.ToListAsync();
		}
		public async Task AddAsync(User user)
		{
			await _userManager.CreateAsync(user);
		}

		public async Task UpdateAsync(User user)
		{
			_userManager.UpdateAsync(user).Wait();
		}
		public async Task DeleteAsync(string id)
		{
			var user = await _userManager.FindByIdAsync(id);

			if (user != null) { 
			await _userManager.DeleteAsync(user);
			}
		}
		public async Task SaveChangesAsync()
		{
			// No-op for UserManager
		}
	}
}
