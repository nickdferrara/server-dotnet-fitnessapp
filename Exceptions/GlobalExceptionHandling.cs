using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace server_dotnet_fitnessapp.Exceptions;

public class GlobalExceptionHandling : IMiddleware
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
                Type = ex.GetType().FullName,
                Detail = ex.Message,
                Status = (int)HttpStatusCode.BadRequest
            };

            string json = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(json);
            context.Response.ContentType = "application/json";
        }
    }
}