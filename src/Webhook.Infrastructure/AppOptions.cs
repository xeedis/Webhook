namespace Webhook.Infrastructure;

public class AppOptions
{
    public string MerchantId { get; set; }
    public Guid ServiceId { get; set; }
    public string ServiceKey { get; set; }
    public string Token { get; set; }
}