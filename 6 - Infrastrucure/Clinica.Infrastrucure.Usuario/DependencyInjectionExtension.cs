using Clinica.Domain.Usuario;
using Clinica.Domain.Usuario.Repositories;
using Clinica.Infrastrucure.Usuario.DataAccess;
using Clinica.Infrastrucure.Usuario.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clinica.Infrastrucure.Usuario
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);

            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            var version = new Version(8, 0, 43);
            var serverVersion = new MySqlServerVersion(version);

            services.AddDbContext<UsuarioDbContext>(config => config.UseMySql(connectionString, serverVersion));
        }

        // Registar as injeções de dependência dos repositórios
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}
