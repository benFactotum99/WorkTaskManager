using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace WorkTaskManagerBackend.Config.Builder
{
    public static class ServiceConfigurator
    {
        internal static void ConfigureDbContext(this WebApplicationBuilder builder, string connectionString)
        {
            builder.Services.AddDbContext<WorkTaskManager>(options =>
            {
                options.UseNpgsql(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
            }, ServiceLifetime.Transient);

            builder.Services.AddDbContext<WorkTaskManagerIdentity>(options =>
            {
                options.UseNpgsql(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
            }, ServiceLifetime.Transient);
        }
        internal static void ConfigureRepositories(this WebApplicationBuilder builder)
        {
            //builder.Services.AddScoped<CustomersRepository>();
        }
        internal static void ConfigureServices(this WebApplicationBuilder builder)
        {
            //builder.Services.AddScoped<CustomersService>();
        }
    }
}
