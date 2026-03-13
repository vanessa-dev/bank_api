using BancoApi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BancoApi.Filters;

public class DomainExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DomainException ex)
        {
            context.Result = new BadRequestObjectResult(new
            {
                message = ex.Message,
                errors = ex.Errors
            });
            context.ExceptionHandled = true;
        }
    }

}