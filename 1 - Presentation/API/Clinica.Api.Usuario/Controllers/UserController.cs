using Clinica.Application.Usuario.UseCases.Usuario.Create;
using Clinica.Communication.Usuario.Request;
using Clinica.Communication.Usuario.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateUserDTO),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromServices] ICreateUserUseCase createUserUseCase,
                                                    [FromBody] RequestCreateUserDTO request)
        {
            var response = await createUserUseCase.Execute(request).ConfigureAwait(false);
            return Created(string.Empty, response);
        }
    }
}
