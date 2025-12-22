using Clinica.Communication.Usuario.Enums;
using Clinica.Communication.Usuario.Request;
using Clinica.Communication.Usuario.Response;
using Clinica.Domain.Usuario;
using Clinica.Domain.Usuario.Entities;
using Clinica.Domain.Usuario.Repositories;
using Clinica.Exception.Usuario;
using Clinica.Exception.Usuario.BaseException;

namespace Clinica.Application.Usuario.UseCases.Usuario.Create
{
    public class CreateUserUseCase(IUserWriteOnlyRepository userWriteOnlyRepository,
                                   IUserReadOnlyRepository userReadOnlyRepository,
                                   IUnitOfWork unitOfWork
                                  ): ICreateUserUseCase
    {

        public async Task<ResponseCreateUserDTO> Execute(RequestCreateUserDTO request)
        {
            await Validate(request);

            var userEntity = new User()
            {
                Email = request.Email,
                EmpresaId = Guid.NewGuid(),
                Name = request.Nome,
                Password = request.Password,
                Role = Roles.ADMIN
            };

            await userWriteOnlyRepository.AddUser(userEntity).ConfigureAwait(false);

            await unitOfWork.Commit().ConfigureAwait(false);

            return new ResponseCreateUserDTO(userEntity.Id, userEntity.Name, userEntity.Email);

        }

        private async Task Validate(RequestCreateUserDTO request)
        {
            var result = new CreateUserValidate().Validate(request);

            if (!result.IsValid)
            {
                var errorMesssages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMesssages);
            }

            var emailAlreadyExists = await userReadOnlyRepository.EmailAlreadyExists(request.Email).ConfigureAwait(false);

            if (emailAlreadyExists)
                throw new ErrorOnValidationException([ResourceErrorMessages.EMAIL_ALREADY_REGISTERED]);

        }
    }
}
