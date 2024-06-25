using Microsoft.AspNetCore.Identity;
using WorkTaskManagerBackend.Config.Builder;

namespace WorkTaskManagerBackend.Config
{
    internal static class ConfigureApp
    {
        internal static WebApplication BuildCustom(this WebApplicationBuilder builder)
        {
            builder.CustomConfigure();
            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Autenticazione
            app.MapIdentityApi<IdentityUser>();

            //app.UseCors("wasm");
            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
