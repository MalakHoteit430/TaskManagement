using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;

namespace TaskManagement.Infrastructure.Data
{
	public static class SeedData
	{
		public static void Initialize(TaskDbContext context)
		{
			context.Database.EnsureCreated();

			// Check if data already exists
			if (context.UserTasks.Any() && context.Projects.Any() && context.Categories.Any())
			{
				return; // Database has been seeded
			}

			// Seed Categories
			var categories = new[]
			{
			new Category { Name = "Personal" },
			new Category { Name = "Work" }
		};
			context.Categories.AddRange(categories);
			context.SaveChanges();

			// Seed Users
			var users = new[]
			{
			new User { UserName = "user1", Email = "user1@example.com" },
			new User { UserName = "user2", Email = "user2@example.com" }
		};
			context.Users.AddRange(users);
			context.SaveChanges();

			// Seed Projects
			var projects = new[]
			{
			new Project { Name = "Project 1", User = users[0], Category = categories[0] },
			new Project { Name = "Project 2", User = users[1], Category = categories[1] }
		};
			context.Projects.AddRange(projects);
			context.SaveChanges();

			// Seed Tasks
			var tasks = new[]
			{
			new UserTask { Title = "Task 1", Description = "Description 1", DueDate = DateTime.Now.AddDays(1), User = users[0], Project = projects[0], Category = categories[0] },
			new UserTask { Title = "Task 2", Description = "Description 2", DueDate = DateTime.Now.AddDays(2), User = users[1], Project = projects[1], Category = categories[1] }
		};
			context.UserTasks.AddRange(tasks);
			context.SaveChanges();

			// Seed Attachments
			var attachments = new[]
			{
			new Attach { FileName = "attachment1.txt", FilePath = "/attachments/attachment1.txt", UserTask= tasks[0] },
			new Attach { FileName = "attachment2.txt", FilePath = "/attachments/attachment2.txt", UserTask = tasks[1] }
		};
			context.Attachments.AddRange(attachments);
			context.SaveChanges();

			// Seed Schedules
		//	var schedules = new[]
		//	{
		//	new Schedule { DayOfWeek = DateTime.Now.DayOfWeek, User = users[0], UserTasks = tasks[0] },
		//	new Schedule { DayOfWeek = DateTime.Now.DayOfWeek, User = users[1], UserTasks = tasks[1] }
		//};
		//	context.Schedules.AddRange(schedules);
		//	context.SaveChanges();

			// Seed Reviews
			var reviews = new[]
			{
			new Review { Comment = "Great app!", Rating = 5, User = users[0] },
			new Review { Comment = "Needs improvement.", Rating = 3, User = users[1] }
		};
			context.Reviews.AddRange(reviews);
			context.SaveChanges();
		}
	}
}
