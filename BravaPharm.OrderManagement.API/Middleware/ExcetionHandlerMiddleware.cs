using System.Net;
using BravaPharm.OrderManagement.Application.Exceptions;
using Newtonsoft.Json;

namespace BravaPharm.OrderManagement.API.Middleware
{
    public class ExcetionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExcetionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                ConvertToHttpStatusCode(context, ex);
            }
        }

        private void ConvertToHttpStatusCode(HttpContext context, Exception ex)
        {

            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = string.Empty;
        


            switch (ex)
            {
                case ValidationException validationEx:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationEx.ValidationErrors);
                    break;
                case NotFoundException notFoundEx:
                    httpStatusCode = HttpStatusCode.NotFound;
                    result = "Query not valid";
                    break;
                //case BadRequestException badRequestException:
                //    httpStatusCode = HttpStatusCode.BadRequest;
                //    result = JsonConvert.SerializeObject(badRequestException.Message);
                //    break;
                case Exception e:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }
            context.Response.StatusCode = (int)httpStatusCode;
            if (result == String.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = ex.Message });
            }
            context.Response.WriteAsync(result);

        }
    }
}
