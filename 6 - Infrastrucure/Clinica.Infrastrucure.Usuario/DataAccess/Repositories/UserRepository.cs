using Clinica.Domain.Usuario.Entities;
using Clinica.Domain.Usuario.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Infrastrucure.Usuario.DataAccess.Repositories
{
    public class UserRepository(UsuarioDbContext dbContext) : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        public async Task AddUser(User user)
        {
          await dbContext.Usuarios.AddAsync(user).ConfigureAwait(false);
        }

        public async Task<bool> EmailAlreadyExists(string email)
        {
           return await dbContext.Usuarios.AnyAsync(u => u.Email == email).ConfigureAwait(false);
        }

        public Task<User?> GetUserByEmail(string email)
        {
            return dbContext.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.Equals(email,StringComparison.InvariantCultureIgnoreCase));

        }
    }
}
