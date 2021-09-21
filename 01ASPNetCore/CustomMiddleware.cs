using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace _01ASPNetCore
{

    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("\n\r --- Before --- \n\r");

            await _next(context);

            Console.WriteLine("\n\r --- After --- \n\r");
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
