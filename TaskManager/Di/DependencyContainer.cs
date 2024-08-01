using TaskManager.Auth.Jwt;
using TaskManager.Data.Module.User.Repository;
using TaskManager.Domain.Module.User.Repository;
using TaskManager.Domain.Module.User.Usecase;

namespace TaskManager.Di
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // DataSource
            services.AddScoped<UserLocalDataSource>();

            // Repository
            services.AddScoped<IUserRepository, UserRepositoryImpl>();

            // Usecase
            services.AddScoped<AddUserUsecase>();
            services.AddScoped<GetUserByCredentialsUsecase>();
            services.AddScoped<GetAllUsersUsecase>();

            // Others
            services.AddScoped<TokenUtils>();
        }
    }
}
