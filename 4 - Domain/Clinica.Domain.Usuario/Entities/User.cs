namespace Clinica.Domain.Usuario.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid EmpresaId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
