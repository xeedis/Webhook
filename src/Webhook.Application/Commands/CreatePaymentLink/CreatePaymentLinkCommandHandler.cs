using MediatR;
using Webhook.Core.Dto;
using Webhook.Core.Interfaces;

namespace Webhook.Application.Commands.CreatePaymentLink;

internal class CreatePaymentLinkCommandHandler : IRequestHandler<CreatePaymentLinkCommand, string>
{
    private readonly IPaymentIngClient _client;

    public CreatePaymentLinkCommandHandler(IPaymentIngClient client)
    {
        _client = client;
    }
    public async Task<string> Handle(CreatePaymentLinkCommand request, CancellationToken cancellationToken)
    {
        return await _client.PaymentLink(new GeneratePaymentLinkDto(
            request.Amount, request.Currency, request.Title, request.FirstName,
            request.LastName, request.Email
        ), cancellationToken);
    }
}