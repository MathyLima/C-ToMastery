using GamingOrganization.Exceptions.ExceptionsBase;
using GammingOrganization.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GamingOrganization.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context) {
            if (context.Exception is GameOrganizationExceptions exception)
            {
                context.HttpContext.Response.StatusCode = (int) exception.GetHttpStatusCode();
                context.Result = new ObjectResult(new ResponseErrorMessagesJson(exception.GetErrors()));
            }
            else
            {
                ThrowUnknownError(context);
            }
        }

        private void ThrowUnknownError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessagesJson("Erro Desconhecido"));
        }
    }
}
