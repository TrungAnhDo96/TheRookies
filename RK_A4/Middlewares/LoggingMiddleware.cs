using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace RK_A4.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            //Stream stream = context.Response.Body;

            using var buffer = new MemoryStream();
            var stream = response.Body;
            response.Body = buffer;
            await _next(context);
            string log = "Schema: " + request.Scheme +
                "\nHost: " + request.Host +
                "\nPath: " + request.Path +
                "\nQuery String: " + request.QueryString +
                "\nRequest Body: \n";
            Debug.Write(log);

            buffer.Position = 0;

            await buffer.CopyToAsync(stream);
        }
    }
}