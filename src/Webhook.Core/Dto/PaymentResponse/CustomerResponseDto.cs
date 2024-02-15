namespace Webhook.Core.Dto.PaymentResponse;

public record CustomerResponseDto
(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Locale
);