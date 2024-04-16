using CashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        //if (context.Exception is ErrorOnValidationException)
    }

    private void HandleProjectException(ExceptionContext context)
    {

    }

    private void ThrowUnknowError(ExceptionContext context)
    {

    }
}
