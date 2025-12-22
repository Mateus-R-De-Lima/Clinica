namespace Clinica.Domain.Usuario
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
