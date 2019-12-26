using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shared.Application.Exceptions;
using Shared.Domain;

namespace API.Infrastructure.Filters
{
#pragma warning disable 1591
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(IWebHostEnvironment environment, ILogger<GlobalExceptionFilter> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
			_logger.LogError(new EventId(context.Exception.HResult), context.Exception, context.Exception.Message);

            if (context.Exception is IDomainException || context.Exception is ValidationException)
            {
                var problemDetails = new ValidationProblemDetails
                {
                    Instance = context.HttpContext.Request.Path,
                    Status = StatusCodes.Status400BadRequest,
                    Detail = "Please refer to the errors property for additional details."
                };

                context.Result = new BadRequestObjectResult(problemDetails);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                switch (context.Exception)
                {
                    case IDomainException _:
                        problemDetails.Errors.Add("DomainValidations", new[] { context.Exception.Message });
                        break;
                    case ValidationException exception:
                        problemDetails.Errors.Add("CommandValidations",
                            exception.Errors.Select(e => e.ErrorMessage).ToArray());
                        break;
                }
            }
            else if (context.Exception is RecordNotFoundException ex)
            {
                var json = new JsonErrorResponse { Messages = new[] { ex.Message } };

                context.Result = new NotFoundObjectResult(json);
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            else
            {
                var json = new JsonErrorResponse { Messages = new[] { "An error occur.Try it again." } };

                if (_environment.IsDevelopment())
                {
                    json.DeveloperMessage = context.Exception;
                }

                context.Result = new ObjectResult(json) {StatusCode = 500};
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
	}

    internal class JsonErrorResponse
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string[] Messages { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public object DeveloperMessage { get; set; }
    }
}
