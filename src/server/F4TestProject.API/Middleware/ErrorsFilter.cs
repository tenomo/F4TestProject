using F4TestProject.Infrastructure.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Net;

namespace F4TestProject.API.Middleware
{
    public class ErrorsFilter : IExceptionFilter
    {
        private readonly IEnumerable<IErrorHandler> errorHandlers;
        public ErrorsFilter()
        {
            errorHandlers = new List<IErrorHandler>()
            {
                new EntryNotFoundHandler(),
                new NotUniqueEntryHandler(),
                new WrongPasswordHandler()
            };
        }
        public void OnException(ExceptionContext context)
        {
            foreach (var handler in errorHandlers)
            {
                handler.Handle(context);
            }
        }
    }

    interface IErrorHandler
    {
        public void Handle(ExceptionContext context);
    }

    public class EntryNotFoundHandler : IErrorHandler
    {
        public void Handle(ExceptionContext context)
        {
            if (context.Exception is EntryNotFoundException)
            {
                context.Result = new ObjectResult(context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
        }
    }

    public class NotUniqueEntryHandler : IErrorHandler
    {
        public void Handle(ExceptionContext context)
        {
            if (context.Exception is NotUniqueEntryException)
            {
                context.Result = new ObjectResult(context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }

    public class WrongPasswordHandler : IErrorHandler
    {
        public void Handle(ExceptionContext context)
        {
            if (context.Exception is AuthenticationFailedException)
            {
                context.Result = new ObjectResult(context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }

}
