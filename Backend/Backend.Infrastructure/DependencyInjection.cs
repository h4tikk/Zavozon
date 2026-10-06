using Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string postgresConnection)
    {
        services.AddDbContext<MarketplaceDbContext>(options =>
            options.UseNpgsql(
                postgresConnection,
                npgsql => npgsql.MigrationsAssembly(typeof(MarketplaceDbContext).Assembly.FullName)));

        return services;
    }
}
