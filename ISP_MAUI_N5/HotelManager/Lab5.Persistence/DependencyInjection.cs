using Lab5.Persistence.Data;
using Lab5.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
            return services;
        }
        public static IServiceCollection AddPersistence(this IServiceCollection services, DbContextOptions options)
        {
            services.AddPersistence().AddSingleton(new ApplicationDbContext((DbContextOptions<ApplicationDbContext>)options));
            return services;
        }
    }
}