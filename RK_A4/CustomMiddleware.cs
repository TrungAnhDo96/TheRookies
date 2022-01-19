using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System;
using System.Threading.Tasks;

namespace RK_A4
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            System.Diagnostics.Debug.WriteLine("Request received.");

            DoSomething();

            await _next(context);

            System.Diagnostics.Debug.WriteLine("Return response.");
        }

        public async void DoSomething()
        {
            System.Diagnostics.Debug.WriteLine("Doing something with the request");
            await Task.Delay(1000);
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}