namespace Webhook.Infrastructure;

internal sealed class IMojeSettings
{
    public const string SectionName = "IMoje";
    public string BaseAddress { get; init; }
    public string MerchantId { get; init; }
    public Guid ServiceId { get; init; }
    public string ServiceKey { get; init; }
    public string ReturnUrl { get; init; }
    public IEnumerable<string> VisibleMethod { get; init; }
    public string Token { get; init; }
}