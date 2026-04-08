using System.Diagnostics;

namespace BancoApi.Middlewares;

public class LoggingMiddleware : IMiddleware
{
    private readonly ILogger<LoggingMiddleware> _logger;
    public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
    {
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var sw = Stopwatch.StartNew();
        _logger.LogInformation(
            "{Method} {Path}", 
            context.Request.Method,
            context.Request.Path
        );
        
        await next(context);
        sw.Stop();
        _logger.LogInformation(
            "← {StatusCode} {Method} {Path} [{Elapsed}ms]",
            context.Response.StatusCode,
            context.Request.Method,
            context.Request.Path,
            sw.ElapsedMilliseconds);
        
    }
}