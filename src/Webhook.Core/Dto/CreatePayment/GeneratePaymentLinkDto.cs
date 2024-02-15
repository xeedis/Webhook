namespace Webhook.Core.Dto;

public record GeneratePaymentLinkDto
(
    int Amount, 
    string Currency, 
    string Title,
    string FirstName, 
    string LastName, 
    string Email
);