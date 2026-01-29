using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Planning.Infrastructure.Data;

namespace Planning
{
    public static class PlanningModuleExtensions
    {
        public static IServiceCollection AddPlanningModule(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SupabaseConnection")!;
            services.AddDbContext<PlanningDbContext>(options =>
            {
                options.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", "planning");
                });
            });

            return services;
        }
    }
}
