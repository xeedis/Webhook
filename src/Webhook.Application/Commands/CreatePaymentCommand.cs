namespace Webhook.Application.Commands;

public record CreatePaymentCommand(Guid ServiceId, int Amount, string Currency, string Title, string OrderId,
    IEnumerable<string> VisibleMethod, string ReturnUrl, string SuccessReturnUrl,
    string FailureReturnUrl, CustomerCommand Customer);