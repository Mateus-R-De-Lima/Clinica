using Clinica.Application.Usuario.Mapper;
using Clinica.Application.Usuario.UseCases.Usuario.Create;
using Clinica.Infrastrucure.Usuario;
using Clinica.Application.Usuario.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Filters;
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

            builder.Services.AddAutoMapper(configureAutoMapper =>
            {
                configureAutoMapper.AddProfile<AutoMapping>();
            });

            builder.Services.AddMvc(option => option.Filters.Add(typeof(ClinicaExecptionFilter)));
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
