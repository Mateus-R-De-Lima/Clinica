using Clinica.Domain.Usuario;

namespace Clinica.Infrastrucure.Usuario.DataAccess
{
    internal class UnitOfWork(UsuarioDbContext dbContext) : IUnitOfWork
    {
        public async Task Commit() => await dbContext.SaveChangesAsync().ConfigureAwait(false);

    }
}
