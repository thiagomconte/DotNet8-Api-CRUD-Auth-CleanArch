using AutoMapper;
using TaskManager.Auth.Jwt;
using TaskManager.Data.Module.Task.Mapper;
using TaskManager.Data.Module.Task.Repository;
using TaskManager.Data.Module.User.Entity;
using TaskManager.Data.Module.User.Mapper;
using TaskManager.Data.Module.User.Repository;
using TaskManager.Data.Module.UserTask.Repository;
using TaskManager.Domain.Module.Task.Repository;
using TaskManager.Domain.Module.Task.Usecase;
using TaskManager.Domain.Module.User.Model;
using TaskManager.Domain.Module.User.Repository;
using TaskManager.Domain.Module.User.Usecase;

namespace TaskManager.Di
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // DataSource
            services.AddScoped<IUserLocalDataSource, UserLocalDataSource>();
            services.AddScoped<TaskLocalDataSource>();

            // Repository
            services.AddScoped<IUserRepository, UserRepositoryImpl>();
            services.AddScoped<ITaskRepository, TaskRepositoryImpl>();

            // Usecase
            services.AddScoped<AddUserUsecase>();
            services.AddScoped<GetUserByCredentialsUsecase>();
            services.AddScoped<GetAllUsersUsecase>();

            services.AddScoped<CreateTaskUsecase>();
            services.AddScoped<AssignTaskUserUsecase>();
            services.AddScoped<GetAllTasksUsecase>();
            services.AddScoped<GetTaskByIdUsecase>();

            // Others
            services.AddScoped<TokenUtils>();
            services.AddAutoMapper(typeof(UserMappingProfile), typeof(TaskMappingProfile));
        }
    }
}
