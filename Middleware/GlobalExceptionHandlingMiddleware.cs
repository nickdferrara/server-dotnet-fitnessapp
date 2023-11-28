using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace server_dotnet_fitnessapp.Middleware;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            
            var problemDetails = new ProblemDetails
            {
                Title = ex.GetType().Name,
                Detail = ex.Message,
                Status = (int)HttpStatusCode.BadRequest
            };
            
            context.Response.Headers.ContentType = "application/json; charset=utf-8";
            string json = JsonSerializer.Serialize(problemDetails);            
            await context.Response.WriteAsync(json);
        }
    }
}