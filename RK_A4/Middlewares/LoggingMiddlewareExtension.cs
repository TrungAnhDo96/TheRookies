using Microsoft.AspNetCore.Builder;

namespace RK_A4.Middlewares
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}