using System.Net;

namespace Clinica.Exception.Usuario.BaseException
{
    public class NotFoundException(string message) : ClinicaException(message)
    {
        public override int StatusCode => (int)HttpStatusCode.NotFound; // 404

        public override List<string> GetErros() =>  [Message];
       
    }
}
