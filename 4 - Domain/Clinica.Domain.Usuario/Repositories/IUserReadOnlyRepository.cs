using Clinica.Domain.Usuario.Entities;

namespace Clinica.Domain.Usuario.Repositories
{
    public interface IUserReadOnlyRepository
    {
        Task<bool> EmailAlreadyExists(string email);

        Task<User?> GetUserByEmail(string email);

    }
}
