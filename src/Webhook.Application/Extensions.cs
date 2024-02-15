using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Webhook.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Extensions).Assembly));
        return services;
    }
}
