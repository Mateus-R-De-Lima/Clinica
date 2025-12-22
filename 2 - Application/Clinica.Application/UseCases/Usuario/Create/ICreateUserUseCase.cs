using Clinica.Communication.Usuario.Request;
using Clinica.Communication.Usuario.Response;

namespace Clinica.Application.Usuario.UseCases.Usuario.Create
{
    public interface ICreateUserUseCase
    {
        Task<ResponseCreateUserDTO> Execute(RequestCreateUserDTO request);
    }
}