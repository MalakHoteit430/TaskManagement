using Mapster;
using TaskManagement.Domain.Models;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application
{
	public class MappingConfig
	{
		public TypeAdapterConfig RegisterMappings()
		{
			var config=new TypeAdapterConfig();
			config.NewConfig<UserTask, UserTaskDto>()

				.Map(dest => dest.Project, src => src.Project)
				.Map(dest => dest.Category, src => src.Category)
				.Map(dest => dest.Attachments, src => src.Attachments);


			config.NewConfig<Category, CategoryDto>()
				.Map(dest=>dest.UserTasks,src=>src.UserTasks)
				.Map(dest=>dest.Projects,src=>src.Projects);

			config.NewConfig<Project, ProjectDto>()
				.Map(dest => dest.Category, src => src.Category);

			config.NewConfig<Schedule,ScheduleDto>()
				.Map(dest => dest.Projects, src => src.Projects)
				.Map(dest=>dest.Tasks,src=>src.UserTasks);


			config.NewConfig<Attach,AttachmentDto>();

			config.NewConfig<User,UserDto>()
				.Map(dest=>dest.Projects,src=>src.Projects)
				.Map(dest => dest.Tasks, src => src.UserTasks)
				.Map(dest => dest.Schedules, src => src.Schedules)
				.Map(dest => dest.Reviews, src => src.Reviews);

			return config;
		}
	}
}
