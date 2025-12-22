using Clinica.Application.Usuario.UseCases.Usuario.Create;
using Clinica.Infrastrucure.Usuario;
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
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapOpenApi();


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
