using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SistemaDeProdutividade.Communication.Responses;
using SistemaDeProdutividade.Exception;
using SistemaDeProdutividade.Exception.ExceptionsBase;
using System.Net;

namespace SistemaDeProdutividade.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is SistemaProdutividadeException)
            HandleProjectException(context);
        else 
            ThrowUnknowException(context);
        
    }

    private void HandleProjectException(ExceptionContext context) 
    {
        if (context.Exception is ErrorOnValidationException) 
        {
            var exception = context.Exception as ErrorOnValidationException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ListErrorsResponseJson(exception.ErrorMessages));
        }
        else if (context.Exception is NotFoundException)
        {
            var exception = context.Exception as NotFoundException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Result = new NotFoundObjectResult(new ErrorResponseJson(ResourceMessagesException.NOT_FOUND));
        }
    }

    private void ThrowUnknowException(ExceptionContext context)
    {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ErrorResponseJson(ResourceMessagesException.UNKNOWN_ERROR));
    }
}
