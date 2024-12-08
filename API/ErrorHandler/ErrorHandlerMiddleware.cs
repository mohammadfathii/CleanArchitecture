using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.API.ErrorHandler;

public class ErrorHandlerMiddleware
{
  private readonly RequestDelegate _request;

  public ErrorHandlerMiddleware(RequestDelegate request)
  {
    _request = request;
  }

  public async Task InvokeAsync(HttpContext httpContext)
  {
    try
    {
      await _request(httpContext);
    }
    catch (Exception e)
    {
      var problemDetails = new ProblemDetails()
      {
        Title = "there is an unexpected error caused this !",
        Status = (int)HttpStatusCode.InternalServerError,
        Detail = e.Message
      };

      var jsonSerializer = JsonSerializer.Serialize(problemDetails);

      httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      httpContext.Response.ContentType = "application/problem+json";
      await httpContext.Response.WriteAsync(jsonSerializer);
    }
  }

}
