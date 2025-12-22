using Clinica.Communication.Usuario.Request;
using Clinica.Exception.Usuario;
using FluentValidation;

namespace Clinica.Application.Usuario.UseCases.Usuario.Create
{
    public class CreateUserValidate : AbstractValidator<RequestCreateUserDTO>
    {
        public CreateUserValidate()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage(ResourceErrorMessages.THE_NAME_IS_REQUIRED)
                .MaximumLength(100).WithMessage(ResourceErrorMessages.THE_NAME_MAX_LENGTH_100);

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage(ResourceErrorMessages.THE_EMAIL_IS_REQUIRED)
                .EmailAddress()
                .When(user => !string.IsNullOrWhiteSpace(user.Email), ApplyConditionTo.CurrentValidator)
                .WithMessage(ResourceErrorMessages.THE_EMAIL_IS_INVALID);

            RuleFor(user => user.Password).SetValidator(new PassordValidator<RequestCreateUserDTO>());

        }
    }
}
