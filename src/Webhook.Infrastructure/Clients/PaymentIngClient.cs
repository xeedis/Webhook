using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Webhook.Application.Commands.CreatePaymentLink;
using Webhook.Core.Dto;
using Webhook.Core.Dto.PaymentResponse;
using Webhook.Core.Interfaces;

namespace Webhook.Infrastructure.Clients;


internal sealed class PaymentIngClient : IPaymentIngClient
{
    private readonly IMojeSettings _settings;
    private readonly HttpClient _client;

    public PaymentIngClient(IOptions<IMojeSettings> settings, HttpClient client)
    {
        _settings = settings.Value;
        _client = client;
    }

    public async Task<string> PaymentLink(GeneratePaymentLinkDto command, CancellationToken cancellationToken = default)
    {
        var data = new
        {
            serviceId = _settings.ServiceId,
            amount = command.Amount,
            currency = command.Currency,
            title = command.Title,
            orderId = Guid.NewGuid(),
            visibleMethod = _settings.VisibleMethod,
            returnUrl = _settings.ReturnUrl,
            customer = new
            {
                firstName = command.FirstName,
                lastName = command.LastName,
                email = command.Email
            }
        };
        var json = JsonSerializer.Serialize(data);

        var response = await _client.PostAsync($"/v1/merchant/{_settings.MerchantId}/payment", 
            new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json), cancellationToken);

        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        
        var paymentResponse = JsonSerializer.Deserialize<LinkResponseDto>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        
        
        return paymentResponse.Payment.Url;
    }
}