using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWithNetCode.Middlewares
{
    public static class MiddlewareExtensions
    {
        // This both are custom middleware .
        // From this which one is configure first will call first during request .

        public static IApplicationBuilder UseSecureMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SecureMiddleware>();
        }

        public static IApplicationBuilder UseSeccondMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SeccondMiddleware>();
        }
    }
}
