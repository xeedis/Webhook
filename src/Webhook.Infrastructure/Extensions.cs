using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Webhook.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection("payment");
        services.Configure<AppOptions>(section);
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.MapControllers();
        return app;
    }
}