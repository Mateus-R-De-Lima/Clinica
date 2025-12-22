using Clinica.Communication.Usuario.Response;
using Clinica.Exception.Usuario;
using Clinica.Exception.Usuario.BaseException;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Clinica.Application.Usuario.Filters
{
    public class ClinicaExecptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ClinicaException )
                HandlerException(context);
            else
                HandlerUnknowException(context);
        }


        private void HandlerException(ExceptionContext context)
        {
            var clinicaException = context.Exception as ClinicaException;
            var errorResponse = new ResponseError(clinicaException!.GetErros());
            context.HttpContext.Response.StatusCode = clinicaException.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }

        private void HandlerUnknowException(ExceptionContext context)
        {
            var errorResponse = new ResponseError(ResourceErrorMessages.UNKNOWN_ERROR);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
