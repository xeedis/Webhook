namespace Webhook.Application.Commands.PaymentLinkResponse;

public record PaymentLinkResponseCommand
(
    Guid Id, 
    string Url, 
    Guid ServiceId, 
    Guid OrderId, 
    string Title, 
    string Simp, 
    int Amount,
    string Currency,
    string ReturnUrl,
    string FailureReturnUrl,
    string SuccessReturnUrl,
    string FirstName, 
    string LastName,
    string Email,
    string Phone,
    string Locale,
    bool IsActive,
    DateTime ValidTo,
    int Created,
    int Modified
);