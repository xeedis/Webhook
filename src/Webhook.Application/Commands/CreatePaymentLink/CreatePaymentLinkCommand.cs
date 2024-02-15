using MediatR;

namespace Webhook.Application.Commands.CreatePaymentLink;

public record CreatePaymentLinkCommand
(
    int Amount, 
    string Currency, 
    string Title,
    string FirstName, 
    string LastName, 
    string Email
) : IRequest<string>;  