namespace GsmPanel.models;

public sealed record SmsMessage
{
    public string Id { get; init; } = Guid.NewGuid().ToString("N");
    public int Index { get; init; }
    public string Status { get; init; } = string.Empty;
    public string Sender { get; init; } = string.Empty;
    public string ReceivedAt { get; init; } = string.Empty;
    public string Body { get; init; } = string.Empty;
}
