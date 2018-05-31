using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WordGrid
{
    internal class HttpExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (HttpException httpException)
            {
                context.Response.StatusCode = httpException.StatusCode;
                var responseFeature = context.Features.Get<IHttpResponseFeature>();
                responseFeature.ReasonPhrase = httpException.Message;
            }
        }
    }

    public class HttpException : Exception
    {
        public HttpException(HttpStatusCode httpStatusCode, string message = null, Exception inner = null) : base(message, inner)
        {
            StatusCode = (int)httpStatusCode;
        }

        public int StatusCode { get; }
    }
}
