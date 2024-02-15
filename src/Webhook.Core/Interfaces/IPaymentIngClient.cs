using Webhook.Core.Dto;

namespace Webhook.Core.Interfaces;

public interface IPaymentIngClient
{
    Task<string> PaymentLink(GeneratePaymentLinkDto command, CancellationToken cancellationToken);
}