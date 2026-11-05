
using Microsoft.Extensions.Primitives;

namespace PeoplePro.Utils;

public class ApiKeyMiddleware(RequestDelegate next)
{
    private const string ApiKeyHeaderName = "ApiKey";

    public async Task InvokeAsync(HttpContext context)
    {
        StringValues stringValues;
        if (!context.Request.Headers.TryGetValue("ApiKey", out stringValues))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Api Key was not provided. (Using ApiKeyMiddleware)");
        }
        else if (!context.RequestServices.GetRequiredService<IConfiguration>().GetValue<string>("ApiKey").Equals((string) stringValues))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized client. (Using ApiKeyMiddleware)");
        }
        else
            await next(context);
    }
}