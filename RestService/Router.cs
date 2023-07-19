using RestService.Endpoint;

namespace RestService;

public static class Router
{
    public static void InitRoutes(WebApplication app)
    {
        SetDefaultRoute(app);
        SetUserRoutes(app);
    }

    private static void SetDefaultRoute(WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");
    }

    private static void SetUserRoutes(WebApplication app)
    {
        app.MapGet("/users", (UserEndpoint endpoint) => endpoint.Get());
    }
}