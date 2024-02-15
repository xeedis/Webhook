using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webhook.Infrastructure.Clients;

namespace Webhook.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<IMojeSettings>().Bind(configuration.GetSection(IMojeSettings.SectionName));
        services.RegisterClient(configuration);
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.MapControllers();
        return app;
    }
}