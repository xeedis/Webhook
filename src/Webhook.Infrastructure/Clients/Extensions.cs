using System.Data.Common;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webhook.Core.Interfaces;

namespace Webhook.Infrastructure.Clients;

internal static class Extensions
{
    public static IServiceCollection RegisterClient(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection(IMojeSettings.SectionName).Get<IMojeSettings>();
        
        services.AddHttpClient<IPaymentIngClient, PaymentIngClient>(cfg =>
        {
            cfg.BaseAddress = new Uri(settings.BaseAddress);
            cfg.DefaultRequestHeaders.Add("Authorization", $"Bearer {settings.Token}");
        });
        return services;
    }
    
}