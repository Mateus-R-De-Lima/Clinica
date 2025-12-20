namespace Clinica.Exception.Usuario.BaseException
{
    public abstract class ClinicaException(string message) : SystemException(message)
    {
        public abstract int StatusCode { get; }

        public abstract List<string> GetErros();
    }
}
