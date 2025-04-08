using AutoMapper;
using Exam.UserManager.Repository;
using Exam.UserManager.Service;
using Exam.UserManager.Service.Security;
using SQLite;

namespace Exam.UserManager.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUserManagerServices(this IServiceCollection services)
        {
            services.AddSingleton<ISQLiteConnection>(sp =>
            {
                var dbPath = Path.Combine(AppContext.BaseDirectory, "UserManager.db");
                return new SQLiteConnection(dbPath);
            });

            services.AddScoped<IUserPermission, UserPermission>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserQueryService, UserQueryService>();
            services.AddScoped<IUserWriteService, UserWriteService>();
            
            var config = new MapperConfiguration(c => {
                c.AddProfile<Service.Automapper.UserMapperProfile>();
                c.AddProfile<UserManager.Automapper.UserMapperProfile>();
            });
            services.AddSingleton<IMapper>(s => config.CreateMapper());

            return services;
        }
    }
}
