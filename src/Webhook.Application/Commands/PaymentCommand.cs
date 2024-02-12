namespace Webhook.Application.Commands;

public record PaymentCommand(Guid Id, string Url, Guid ServiceId, string OrderId, string Title,
    string Simp, int Amount, string Currency, string ReturnUrl, string FailureReturnUrl,
    string SuccessReturnUrl, CustomerCommand Customer);