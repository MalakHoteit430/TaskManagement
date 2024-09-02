
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using TaskManagement.Infrastructure.Data;
using TaskManagement.Domain.Models;
using Microsoft.OpenApi.Models;
using TaskManagement.Application;
using Mapster;
using MapsterMapper;
using MediatR;
using TaskManagement.Api.Controllers;
using TaskManagement.Application.Repositories;
using TaskManagement.Infrastructure.Repositories;
using TaskManagement.Application.UserTasks.Handlers;
using TaskManagement.Application.UserTasks.Commands;
using TaskManagement.Application.UserTasks.Queries;
using TaskManagement.Application.Categories.Handlers;
using TaskManagement.Application.Categories.Queries;
using TaskManagement.Application.Categories.Commands;
using TaskManagement.Application.Schedules.Queries;
using TaskManagement.Application.Schedules.Commands;

using TaskManagement.Application.Schedules.Handlers;
using TaskManagement.Application.Reviews.Handlers;
using TaskManagement.Application.Reviews.Commands;
using TaskManagement.Application.Reviews.Queries;
using TaskManagement.Application.Attachments.Handlers;
using TaskManagement.Application.Attachments.Commands;
using TaskManagement.Application.Attachments.Queries;
using TaskManagement.Application.Users.Handlers;
using TaskManagement.Application.Users.Commands;
using TaskManagement.Application.Users.Queries;
using TaskManagement.Application.Projects.Handlers;
using TaskManagement.Application.Projects.Commands;
using TaskManagement.Application.Projects.Queries;
using System.Net.Mail;
using FluentValidation;
using TaskManagement.Application.Attachments.Validators;
using TaskManagement.Application.Categories.Validators;
using TaskManagement.Application.Projects.Validators;
using TaskManagement.Application.Schedules.Validators;
using TaskManagement.Application.Reviews.Validators;
using TaskManagement.Application.UserTasks.Validators;
using TaskManagement.Application.Users.Validators;


var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddDbContext<TaskDbContext>(options =>
	options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireUppercase = true;
	options.Password.RequiredLength = 6;
	options.Password.RequiredUniqueChars = 1;
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
	options.Lockout.MaxFailedAccessAttempts = 5;
	options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
	options.User.RequireUniqueEmail = true;
})
	.AddEntityFrameworkStores<TaskDbContext>()
	.AddDefaultTokenProviders();

// Add controllers
builder.Services.AddControllers();



builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
	typeof(GetUserTaskByIdHandler).Assembly
	, typeof(GetUserTaskByIdQuery).Assembly
	, typeof(CreateUserTaskCommand).Assembly
	, typeof(UserTask).Assembly
	, typeof(UserTaskController).Assembly

	, typeof(GetCategoryByIdHandler).Assembly
	, typeof(GetCategoryByIdQuery).Assembly
	, typeof(CreateCategoryCommand).Assembly
	, typeof(Category).Assembly
	, typeof(CategoryController).Assembly

	, typeof(GetScheduleByIdHandler).Assembly
	, typeof(GetScheduleByIdQuery).Assembly
	, typeof(CreateScheduleCommand).Assembly
	, typeof(Schedule).Assembly
	, typeof(ScheduleController).Assembly

	, typeof(GetReviewByIdHandler).Assembly
	, typeof(GetReviewByIdQuery).Assembly
	, typeof(CreateReviewCommand).Assembly
	, typeof(Review).Assembly
	, typeof(ReviewController).Assembly

	, typeof(GetAttachmentByIdHandler).Assembly
	, typeof(GetAttachmentByIdQuery).Assembly
	, typeof(CreateAttachmentCommand).Assembly
	, typeof(Attachment).Assembly
	, typeof(AttachController).Assembly

	, typeof(GetUserByIdHandler).Assembly
	, typeof(GetUserByIdQuery).Assembly
	, typeof(RegisterUserCommand).Assembly
	, typeof(User).Assembly
	, typeof(UserController).Assembly

	, typeof(GetProjectByIdHandler).Assembly
	, typeof(GetProjectByIdQuery).Assembly
	, typeof(CreateProjectCommand).Assembly
	, typeof(Project).Assembly
	, typeof(ProjectController).Assembly
	));


//validators
builder.Services.AddValidatorsFromAssemblyContaining<CreateAttachmentValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProjectValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateScheduleValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateReviewValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserTaskValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();




builder.Services.AddScoped<IUserTaskRepository, UserTaskRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IAttachmentRepository, AttachmentRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

var mappingConfig = new MappingConfig();
builder.Services.AddSingleton(mappingConfig.RegisterMappings());
builder.Services.AddSingleton<IMapper, Mapper>();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task Management API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


//seed data
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<TaskDbContext>();

	SeedData.Initialize(context);
}

app.Run();