
using System.Net;

namespace Clinica.Exception.Usuario.BaseException
{
    public class ErrorOnValidationException(List<string> errorMessages) : ClinicaException(string.Empty)
    {
        public override int StatusCode => (int)HttpStatusCode.BadRequest; // 400

        public override List<string> GetErros()
        {
            return errorMessages;
        }
    }
}
