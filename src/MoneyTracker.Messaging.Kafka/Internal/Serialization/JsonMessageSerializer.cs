using System.Text.Json;

namespace MoneyTracker.Messaging.Abstractions.Internal.Serialization
{
  public sealed class JsonMessageSerializer : IMessageSerializer
  {
    public string Serialize<T>(T message)
      => JsonSerializer.Serialize(message);

    public T Deserialize<T>(string payload)
      => JsonSerializer.Deserialize<T>(payload)!;
  }
}