using Lab5.Domain.Abstractions;
using Lab5.Persistence.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Lab5.Persistence.UnitOfWork;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(conf =>
            conf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return services;
    }
}