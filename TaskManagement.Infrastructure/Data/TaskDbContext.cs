using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Models;

namespace TaskManagement.Infrastructure.Data
{
	public class TaskDbContext : IdentityDbContext<User>
	{
		public TaskDbContext(DbContextOptions<TaskDbContext> options)
			: base(options)
		{
		}

		public DbSet<UserTask> UserTasks { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Schedule> Schedules { get; set; }
		public DbSet<Attach> Attachments { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Tasks relationships
			modelBuilder.Entity<UserTask>()
				.HasOne(t => t.Project)
				.WithMany(p => p.UserTasks)
				.HasForeignKey(t => t.ProjectId)
				.OnDelete(DeleteBehavior.Cascade);


			modelBuilder.Entity<UserTask>()
				.HasOne(t => t.Category)
				.WithMany(c => c.UserTasks)
				.HasForeignKey(t => t.CategoryId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<UserTask>()
				.HasMany(t=>t.Attachments)
				.WithOne(c => c.UserTask)
				.HasForeignKey(c => c.UserTaskId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<UserTask>()
			.HasMany(t => t.Schedules)
			.WithMany(s => s.UserTasks);


		


			// Project relationships
			modelBuilder.Entity<Project>()
				.HasOne(p => p.Category)
				.WithMany(c => c.Projects)
				.HasForeignKey(p => p.CategoryId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Project>()
				.HasMany(p => p.Schedules)
				.WithMany(s => s.Projects);

		

			// Schedule relationships
			modelBuilder.Entity<Schedule>()
				.HasOne(s => s.User)
				.WithMany(u => u.Schedules)
				.HasForeignKey(s => s.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			
			modelBuilder.Entity<Schedule>()
				.HasMany(s => s.UserTasks)
				.WithMany(p => p.Schedules);

			modelBuilder.Entity<Schedule>()
				.HasMany(s => s.Projects)
				.WithMany(p => p.Schedules);

			
			// User relationships
			modelBuilder.Entity<User>()
				.HasMany(r => r.Reviews)
				.WithOne(u => u.User)
				.HasForeignKey(u => u.UserId)
				.OnDelete(DeleteBehavior.Restrict);


			modelBuilder.Entity<User>()
				.HasMany(u => u.UserTasks)
				.WithOne(t => t.User)
				.HasForeignKey(t => t.UserId);

			modelBuilder.Entity<User>()
				.HasMany(u => u.Projects)
				.WithOne(p => p.User)
				.HasForeignKey(p => p.UserId);


			modelBuilder.Entity<User>()
				.HasMany(u => u.Schedules)
				.WithOne(p => p.User)
				.HasForeignKey(p => p.UserId);

			//Review relationship

			modelBuilder.Entity<Review>()
				.HasOne(r => r.User)
				.WithMany(u => u.Reviews)
				.HasForeignKey(r => r.UserId);
		}
	
	}
}
