using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewTemplateManager.Infrastructure.GlobalExceptionHandler
{

    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {


            var exceptionHandlerFeature = httpContext.Features.Get<IExceptionHandlerFeature>();

            (int statusCode, string title, string type) = exception switch
            {
                InvalidCastException invalidCastException => (400, invalidCastException.Message, ""),
                AggregateException aggregateException => (400, aggregateException.Message, ""),
                ArgumentNullException argumentNullException => (400, argumentNullException.Message, ""),
                ArgumentException argumentException => (500, argumentException.Message, ""),
                DuplicateException duplicateException => (409, duplicateException.Message, duplicateException.Type),
                // ValidationException validationException => (400, validationException.Message),
                KeyNotFoundException keyNotFoundException => (404, keyNotFoundException.Message, ""),
                FormatException formatException => (400, formatException.Message, ""),
                MySqlException mySqlException => (400, mySqlException.Message, ""),
                //ForbidException => (403, "Forbidden"),
                BadHttpRequestException => (400, "Bad request", ""),
                NotImplementedException notImplementedException => (500, notImplementedException.Message, ""),
                NotFoundException notfnotfound => (404, notfnotfound.Message, notfnotfound.Type),
                UnauthorizedAccessException unauthorizedAccessException => (401, unauthorizedAccessException.Message, ""),
                InvalidOperationException invalidOperationException => (500, invalidOperationException.Message, ""),
                _ => (500, "An error occured @" + exception.Message, "")
            };



            var problemDetails = new ProblemDetails
            {

                Detail = exception.InnerException?.Message ?? exception.Message,
                Type = type,
                Title = title,
                Status = statusCode,
                Instance = exceptionHandlerFeature?.Endpoint?.ToString() ?? httpContext.Request.Path,

            };
            _logger.LogError("Exception and problem details {0},{1}", JsonConvert.SerializeObject(problemDetails), exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;

        }


    }
}
