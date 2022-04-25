using Microsoft.AspNetCore.Builder;

namespace Monkeylab.Templates.Api.Commons.Extensions
{
    public static class HeaderExtension
    {
        public static void AddSwaggerApp(this IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "Deny");
                context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
                context.Response.Headers.Add("Permissions-Policy", "geolocation=(), midi=(), camera=(),usb=(), magnetometer=(), sync-xhr=(), microphone=(), camera=(), gyroscope=(), payment=()");
                context.Response.Headers.Add("Content-Security-Policy", "default-src https:; style-src https:; img-src https: data:; font-src https: data:; script-src https:; connect-src https:; frame-ancestors https:; form-action https:; base-uri https:; object-src 'none'");
                context.Response.Headers.Add("Expect-CT", "max-age=0");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
                
                return next.Invoke();
            });
        }
    }
}