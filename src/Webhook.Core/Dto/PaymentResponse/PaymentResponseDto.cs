namespace Webhook.Core.Dto.PaymentResponse;

public record PaymentResponseDto
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
    CustomerResponseDto Customer,
    bool IsActive,
    DateTime? ValidTo,
    int Created,
    int Modified
);