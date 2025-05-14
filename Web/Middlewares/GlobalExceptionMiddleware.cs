using System.Text.Json;

namespace Web.Middlewares;

public class GlobalExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try { await next(context).ConfigureAwait(false); }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                error = "Something went wrong",
                detail = ex.Message
            })).ConfigureAwait(false);
        }
    }
}