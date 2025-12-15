using Clinica.Domain.Usuario.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Infrastrucure.Usuario.DataAccess
{
    public class UsuarioDbContext : DbContext
    {
        public DbSet<User> Usuarios { get; set; }

        public UsuarioDbContext(DbContextOptions options): base(options) { }
      
    }
}
