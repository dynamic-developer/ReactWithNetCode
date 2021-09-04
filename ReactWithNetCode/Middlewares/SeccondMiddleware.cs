using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ReactWithNetCode.Middlewares
{
    public class SeccondMiddleware
    {
        private readonly RequestDelegate _next;

        public SeccondMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Same as describe in SecureMiddleware.cs you can put your own condiation over here and control user request.

            if (true)
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Invalid calling.");
                return;
            }
        }
    }
}
