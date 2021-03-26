using Market.Applictaion.DTOs;
using Market.Applictaion.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Market.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _request;


        public ExceptionMiddleware(RequestDelegate next)
        {
            _request = next;

        }

        public async Task Invoke(HttpContext context) => await this.InvokeAsync(context);

        async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }

            catch (Exception exception)
            {


                var response = GenerateResponse(exception);
                await InvokeException(context, HttpStatusCode.InternalServerError, response);
            }

        }

        private ResponseModel<object> GenerateResponse(Exception ex)
        {
            return ResponseModel<object>.Create(ResponseType.Error, ex.StackTrace, ex.Message);
        }

        private static async Task InvokeException(HttpContext context, HttpStatusCode statusCode, ResponseModel<object> response)
        {
            context.Response.StatusCode = (int)statusCode;
            var jsonOptions = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response, jsonOptions));
        }
    }
}
