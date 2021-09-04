using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReactWithNetCode.Middlewares
{
    public class SecureMiddleware
    {
        private readonly RequestDelegate _next;
        
        public SecureMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            StringValues browserType;
            context.Request.Headers.TryGetValue("User-Agent", out browserType);

            // Here I have blocked the request comes from mobile devices.
            // But you can do anything.
            // You can control user who is continuously requesting.
            // You can allow him limited request in a day or a single request per minutes etc.
            // its depends on what you want.

            if (browserType.Count > 0 && browserType[0] == "mobile")
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Invalid calling.");
                return; 
            }
            else
            {
                await _next(context);
            }
        }
    }
}
