using System;
using System.Text.Json;
using System.Threading.Tasks;
using LibrarySearchService.Core.Services.Contracts;
using Microsoft.AspNetCore.Http;

namespace LibrarySearchService.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        protected readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(RequestDelegate next) => this.next = next;

        public async Task Invoke(HttpContext httpContext, ILogService logService)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, logService, ex);
            }
        }

        private Task HandleExceptionAsync(
            HttpContext context,
            ILogService logService,
            Exception exception)
        {
            logService.LogError(exception);
            string text = JsonSerializer.Serialize((object)new
            {
                ErrorCode = 505,
                Data = logService.CorrelationId.ToString()
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            return context.Response.WriteAsync(text);
        }
    }
}
