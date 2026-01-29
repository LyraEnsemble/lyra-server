using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Catalog.Infrastructure.Data;

namespace Catalog
{
    public static class CatalogModuleExtensions
    {
        public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SupabaseConnection")!;
            services.AddDbContext<CatalogDbContext>(options =>
            {
                options.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", "catalog");
                });
            });

            return services;
        }
    }
}
