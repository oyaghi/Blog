namespace Blog.Infrastructure.Services;

public interface IIdentityManager
{
    int? GetUserId();
}

public class IdentityManager : IIdentityManager
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public IdentityManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int? GetUserId()
    {
        var userIdHeader = _httpContextAccessor.HttpContext?.Request.Headers["X-Correlation-Id"];
        if (!string.IsNullOrWhiteSpace(userIdHeader) && int.TryParse(userIdHeader, out var userId))
        {
            return userId; 
        }

        var userIdRoute = _httpContextAccessor.HttpContext?.Request.RouteValues["userId"];
        if (userIdRoute != null && int.TryParse(userIdRoute.ToString(), out var uId))
        {
            return uId;
        }
        
        return null;
    }
}