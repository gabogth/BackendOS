using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using nest.core.dominio;
using nest.core.dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace nest.core.aplication.auth
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (IdentityException iex)
            {
                _logger.LogError(iex, "IdentityException exception: {TraceId}", context.TraceIdentifier);
                await WriteResponseAsync(context, HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    Type = $"https://httpstatuses.io/{(int)HttpStatusCode.BadRequest}",
                    Title = "Internal Server Error",
                    Status = (int)HttpStatusCode.BadRequest,
                    Errors = iex.Errors.Select(e => new ErrorItem { Field = e.Code, Message = e.Description }),
                    TraceId = context.TraceIdentifier
                });
            }
            catch (dominio.Excepciones.ValidationException vex)
            {
                _logger.LogWarning(vex, "Validation failed: {TraceId}", context.TraceIdentifier);
                await WriteResponseAsync(context, HttpStatusCode.BadRequest, new ErrorResponse
                {
                    Type = $"https://httpstatuses.io/{HttpStatusCode.BadRequest}",
                    Title = "Validation failed",
                    Status = (int)HttpStatusCode.BadRequest,
                    Errors = vex.Errors.Select(e => new ErrorItem { Field = e.PropertyName, Message = e.ErrorMessage }),
                    TraceId = context.TraceIdentifier
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception: {TraceId}", context.TraceIdentifier);
                await WriteResponseAsync(context, HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    Type = $"https://httpstatuses.io/{(int)HttpStatusCode.InternalServerError}",
                    Title = "Internal Server Error",
                    Status = (int)HttpStatusCode.InternalServerError,
                    Detail = GetMessage(ex),
                    TraceId = context.TraceIdentifier
                });
            }
        }

        private static async Task WriteResponseAsync(HttpContext context, HttpStatusCode statusCode, object problem)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var json = JsonSerializer.Serialize(problem, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(json);
        }

        private string GetMessage(Exception exception)
        {
            string message = string.Empty;
            if (exception.InnerException != null && !string.IsNullOrWhiteSpace(exception.InnerException.Message))
                message = exception.InnerException.Message;
            if (!string.IsNullOrWhiteSpace(exception.Message))
                message += (message.Length > 0 ? " - " : string.Empty) + exception.Message;
            return message;
        }
    }
}
