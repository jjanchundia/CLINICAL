using CLINICAL.Application.UseCase.Commonds.Bases;
using CLINICAL.Application.UseCase.Commonds.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace CLINICAL.Api.Extensions.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Application.UseCase.Commonds.Exceptions.ValidationException e)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                { 
                    Message = "Errores de validación",
                    Errors = e.Errors
                });
            }
        }
    }
}