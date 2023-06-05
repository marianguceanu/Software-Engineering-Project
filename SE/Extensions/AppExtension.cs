using Microsoft.EntityFrameworkCore;
using SE.Data;
using SE.Middleware;
using SE.Repository;
using SE.Repository.Interfaces;

namespace SE.Extensions
{
    public static class AppExtension
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlite(config.GetConnectionString("LocalConnection")));
            return services;
        }

        public static IServiceCollection AddMiddleware(this IServiceCollection services)
        {
            services.AddCors();
            services.AddSingleton<ErrorHandlerMiddleware>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDestinationRepository, DestinationRepository>();
            services.AddScoped<IUserDestinationRepository, UserDestinationRepository>();
            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SE.Mappings.Mappings));
            return services;
        }
    }
}