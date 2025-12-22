using Clinica.Exception.Usuario;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Clinica.Application.Usuario.UseCases.Usuario
{
    public partial class PassordValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "PassordValidator";

        private const string ERROR_MESSAGE_KEY = "ErrorMessage";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{ERROR_MESSAGE_KEY}}}";
        }


        public override bool IsValid(ValidationContext<T> context, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.THE_EMAIL_IS_REQUIRED);
                return false;
            }

            if (password.Length < 6)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.THE_PASSWORD_MIN_LENGTH_6);
                return false;
            }
            if (password.Length > 50)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.THE_PASSWORD_MAX_LENGTH_50);
                return false;
            }
            if (!LowerCaseLetter().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.THE_PASSWORD_MUST_CONTAIN_LOWERCASE_LETTER);
                return false;
            }
            if (!UpperCaseLetter().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.THE_PASSWORD_MUST_CONTAIN_UPPERCASE_LETTER);
                return false;
            }
            if (!Numbers().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY,ResourceErrorMessages.THE_PASSWORD_MUST_CONTAIN_NUMBER);
                return false;
            }

            if (!SpecialSymbols().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.THE_PASSWORD_MUST_CONTAIN_SPECIAL_SYMBOL);
                return false;
            }


            return true;
        }



        [GeneratedRegex(@"[A-Z]+")]
        private static partial Regex UpperCaseLetter();
        [GeneratedRegex(@"[a-z]+")]
        private static partial Regex LowerCaseLetter();
        [GeneratedRegex(@"[0-9]+")]
        private static partial Regex Numbers();
        [GeneratedRegex(@"[\!\?\*\.\%\@]+")]
        private static partial Regex SpecialSymbols();


    }
}
