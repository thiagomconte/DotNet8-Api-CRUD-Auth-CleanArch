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
            services.AddSingleton<UserLocalDataSource>();

            // Repository
            services.AddSingleton<IUserRepository, UserRepositoryImpl>();

            // Usecase
            services.AddSingleton<AddUserUsecase>();
            services.AddSingleton<GetUserByCredentialsUsecase>();

            // Others
            services.AddSingleton<TokenUtils>();
        }
    }
}
