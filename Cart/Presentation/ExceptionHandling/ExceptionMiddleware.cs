using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Presentation.ExceptionHandling
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ArgumentNullException ex)
            {
                await HandleArgumentNullExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, string.Empty);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new ErrorResultModel()
            {
                StatusCode = context.Response.StatusCode,
                Message = CartConstants.InternalServerErrorResponseMessage
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private async Task HandleArgumentNullExceptionAsync(HttpContext context, ArgumentNullException exception)
        {
            _logger.LogError(exception, string.Empty);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var response = new ErrorResultModel()
            {
                StatusCode = context.Response.StatusCode,
                Message = CartConstants.BadRequestResponseMessage
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
