using Microsoft.AspNetCore.Antiforgery;

namespace Web_CSRF_API.Middleware
{
    public class AntiforgeryMiddleware : IMiddleware
    {
        private readonly IAntiforgery _antiforgery;

        public AntiforgeryMiddleware(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var tokens = _antiforgery.GetAndStoreTokens(context);
            context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken!,
                    new CookieOptions { HttpOnly = false });

            return next(context);
        }
    }
}
