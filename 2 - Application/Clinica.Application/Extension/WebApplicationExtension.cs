using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Clinica.Application.Usuario.Extension
{
    public static class WebApplicationExtension
    {
        public static WebApplication WebApplicationExtensionBuilder(this WebApplicationBuilder builder)
        {
            // Add services to the container.

            builder.Services.AddControllers();
  
            builder.Services.AddOpenApi();

            var app = builder.Build();

           
            app.MapOpenApi();


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
