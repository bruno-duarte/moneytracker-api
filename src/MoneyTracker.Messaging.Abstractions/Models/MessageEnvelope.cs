namespace MoneyTracker.Messaging.Abstractions.Models
{
  public sealed record MessageEnvelope
  {
    public string MessageId { get; init; } = Guid.NewGuid().ToString();
    public string MessageType { get; init; } = default!;
    public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
    public object Payload { get; init; } = default!;
    public IReadOnlyDictionary<string, string> Headers { get; init; }
        = new Dictionary<string, string>();
  }
}