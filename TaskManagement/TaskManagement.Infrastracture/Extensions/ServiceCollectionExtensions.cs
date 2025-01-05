using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Interfaces;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TaskManagementDbContext>(opts
            => opts.UseSqlServer(configuration.GetConnectionString("TaskManagementDb")));

        services
            .AddScoped<ITaskRepository, TaskRepository>();
        
        return services;
    }

}
