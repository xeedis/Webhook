using Microsoft.Extensions.DependencyInjection;

namespace Webhook.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
         {
        return services;
    }
}
