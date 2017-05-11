using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Workoutplaner.Server.Services;

namespace Workoutplaner.Server.Middlewares
{
    public class ApiExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityNotFoundException ex)
            {
                await WriteAsJsonAsync(context, HttpStatusCode.NotFound, new { message = ex.Message });
            }
        }

        private async Task WriteAsJsonAsync(
            HttpContext context, HttpStatusCode statusCode, object payload, bool clearBeforeWrite = true)
        {
            if (clearBeforeWrite)
            {
                context.Response.Clear();
            }

            context.Response.StatusCode = (int)statusCode;

            context.Response.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(payload);

            // BUG Browser link kikapcsolása után az ékezetes karakterek összekavarják a válasz hosszát, így most ne állítsuk be
            // context.Response.ContentLength = json.Length;

            await context.Response.WriteAsync(json);
        }
    }
}
