using Webhook.Core.Entities;

namespace Webhook.Application.Services;

public class PaymentService : IPaymentService
{
    public Task<string> CreateAsync(Order order)
    {
        using (HttpClient client = new HttpClient())
        {
            throw new NotImplementedException();
        }
    }
}