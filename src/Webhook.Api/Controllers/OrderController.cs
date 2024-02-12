using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Webhook.Application.Commands;
using Webhook.Application.DTO;
using Webhook.Infrastructure;

namespace Webhook.Api.Controllers;

[ApiController]
[Route("orders")]
public class OrderController : ControllerBase
{
    private readonly AppOptions _options;

    public OrderController(IOptionsSnapshot<AppOptions> options)
    {
        _options = options.Value;
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateOrder(CreatePaymentCommand command)
    {
        var client = new HttpClient();
        var body = command with { ServiceId = _options.ServiceId };
        
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _options.Token);
        string _address = $"https://sandbox.api.imoje.pl/v1/merchant/{_options.MerchantId}/payment";

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        var json = JsonSerializer.Serialize(body, options);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync(_address, data);

        if (!response.IsSuccessStatusCode)
        {
            return NotFound();
        }

        var jsonString = await response.Content.ReadAsStringAsync();
        var paymentResponse = JsonSerializer.Deserialize<PaymentResponseCommand>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return Ok(paymentResponse.Payment.Url);
    }
}