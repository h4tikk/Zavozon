using Backend.Infrastructure.Persistence;
using Backend.Infrastructure.Persistence.Repositories;
using Backend.Model.Abstractions;
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

        services.AddScoped<IUnitOfWork>(serviceProvider =>
            serviceProvider.GetRequiredService<MarketplaceDbContext>());
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISellerRepository, SellerRepository>();
        services.AddScoped<ICourierRepository, CourierRepository>();
        services.AddScoped<IPickUpPointRepository, PickUpPointRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IPaymentClaimRepository, PaymentClaimRepository>();

        return services;
    }
}
