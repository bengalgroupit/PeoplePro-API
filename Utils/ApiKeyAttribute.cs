using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PeoplePro.Utils;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAttribute : Attribute, IAsyncActionFilter, IFilterMetadata
{
    private const string ApiKeyHeaderName = "ApiKey";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        
        var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var settings = configuration.GetSection("Settings").Get<Settings>();

        
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKeyHeaderValue))
        {
            context.Result = new ContentResult
            {
                StatusCode = 401,
                Content = "API Key was not provided."
            };
            return;
        }

        if (settings == null || string.IsNullOrEmpty(settings.ApiKey))
        {
            context.Result = new ContentResult
            {
                StatusCode = 401,
                Content = "Invalid API Key configuration."
            };
            return;
        }

        if (!settings.ApiKey.Equals(apiKeyHeaderValue))
        {
            context.Result = new ContentResult
            {
                StatusCode = 401,
                Content = "Unauthorized client."
            };
            return;
        }
        await next();
    }
}