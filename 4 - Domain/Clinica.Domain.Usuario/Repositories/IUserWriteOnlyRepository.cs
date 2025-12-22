using Clinica.Domain.Usuario.Entities;

namespace Clinica.Domain.Usuario.Repositories
{
    public interface IUserWriteOnlyRepository
    {
        Task AddUser(User user);
    }
}
