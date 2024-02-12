using Webhook.Core.Entities;

namespace Webhook.Application.Services;

public interface IPaymentService
{
    Task<string> CreateAsync(Order order);
}