using Microsoft.Extensions.DependencyInjection;

namespace Webhook.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}