using AutoMapper;
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
                                   IUnitOfWork unitOfWork,
                                   IMapper mapper
                                  ): ICreateUserUseCase
    {

        public async Task<ResponseCreateUserDTO> Execute(RequestCreateUserDTO request)
        {
            await Validate(request);

            var userEntity = mapper.Map<User>(request);

            //TODO: Receber de quest o Role e EmpresaId
            userEntity.EmpresaId = Guid.NewGuid();
            userEntity.Role = Roles.ADMIN;

            await userWriteOnlyRepository.AddUser(userEntity).ConfigureAwait(false);

            await unitOfWork.Commit().ConfigureAwait(false);

            var response = mapper.Map<ResponseCreateUserDTO>(userEntity);

            return response;

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
