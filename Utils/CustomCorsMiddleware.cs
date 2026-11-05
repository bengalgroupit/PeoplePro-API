namespace PeoplePro.Utils;

public class CustomCorsMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        // Allow specific origins instead of "*"
        context.Response.Headers["Access-Control-Allow-Origin"] = "https://your-allowed-origin.com";
        context.Response.Headers["Access-Control-Allow-Methods"] = "GET, POST, PUT, DELETE, OPTIONS";
        context.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type, Authorization";
        context.Response.Headers["Access-Control-Allow-Credentials"] = "true"; // Needed if authentication is used

            
        if (context.Request.Method == HttpMethods.Options)
        {
            context.Response.StatusCode = 204; // No Content is preferred for preflight responses
            return;
        }

        await next(context);
    }
}