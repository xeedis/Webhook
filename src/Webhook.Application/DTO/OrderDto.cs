namespace Webhook.Application.DTO;

public class OrderDto
{
    public Guid ServiceId { get; set; }
    public int Amount { get; set; }
    public string Currency { get; set; }
    public string Title { get; set; }
    public string OrderId { get; set; }
    public IEnumerable<string> VisibleMethod { get; set; }
    public string ReturnUrl { get; set; }
    public string SuccessReturnUrl { get; set; }
    public string FailureReturnUrl { get; set; }
    public CustomerDto Customer { get; set; }
} 