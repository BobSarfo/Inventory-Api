using Inventory.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Inventory.Shared.Exceptions
{
    internal sealed class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ErrorHandlerMiddleware(
            ILogger<ErrorHandlerMiddleware> logger, IHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                if (ex is InventoryException) 
                { 
                    await HandleCustomErrorAsync(context, ex);
                }
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var development = new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString());
                if (ex.InnerException != null)
                {
                    development.Details = ex.InnerException.StackTrace;
                    development.Message = ex.InnerException.Message;
                }
                var production = new ApiException(context.Response.StatusCode, "Internal Server Error, An unexpected error occurred.Please try again later");

                var response = _env.IsDevelopment() ? development : production;

                var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, option);
                await context.Response.WriteAsync(json);
            }
        }

        private async Task HandleCustomErrorAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var development = new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString());
            if (ex.InnerException != null)
            {
                development.Details = ex.InnerException.StackTrace;
                development.Message = ex.InnerException.Message;
            }
            var production = new ApiException(context.Response.StatusCode, development.Message);

            var response = _env.IsDevelopment() ? development : production;

            var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, option);
            await context.Response.WriteAsync(json);

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}