using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorldRank.Application.Interfaces;
using WorldRank.Infrastructure.Persistence;
using WorldRank.Infrastructure.Repositories;

namespace WorldRank.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddDbContext<WorldRankDbContext>(options =>
        {
            options.UseSqlServer(
                "Server=MYDESKTOP\\SQLEXPRESS;" +
                "Database=WorldRank;" +
                "Integrated Security=true;" +
                "TrustServerCertificate=true");
        });

        services.AddSingleton<IPlayerRepository,
            InMemoryPlayerRepository>();

        services.AddSingleton<IWalletRepository,
            InMemoryWalletRepository>();

        return services;
    }
}