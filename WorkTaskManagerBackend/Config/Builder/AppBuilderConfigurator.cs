using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using WorkTaskManagerBackend.Config.Settings;

namespace WorkTaskManagerBackend.Config.Builder
{
    internal static class AppBuilderConfigurator
    {
        internal static void CustomConfigure(this WebApplicationBuilder builder)
        {
            AppSettings settings = builder.ConfigureSettingsSection<AppSettings>("ApiSettings");

            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
            builder.ConfigureDbContext(settings.ConnectionStrings.cnn);
            builder.ConfigureRepositories();
            builder.ConfigureServices();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();

            });


            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Log_TaskManager\\ApiLog-.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            //Autenticazione
            builder.Services.AddAuthorization();
            builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<WorkTaskManagerIdentity>();

            builder.Services.AddCors(opts => opts.AddDefaultPolicy(bld => // <-- added this
            {
                bld
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("*")
                ;
            }));
        }

        private static T ConfigureSettingsSection<T>(this WebApplicationBuilder builder, string sectionName) where T : class
        {
            builder.Services.Configure<T>(builder.Configuration.GetSection(sectionName));
            return builder.Configuration.GetSection(sectionName).Get<T>();
        }
    }
}
