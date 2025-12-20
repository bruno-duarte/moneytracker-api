using MoneyTracker.Messaging.Abstractions.Models;

namespace MoneyTracker.Messaging.Abstractions
{
  public interface IMessageProducer
  {
    Task PublishAsync(string topic, MessageEnvelope message, CancellationToken cancellationToken = default);
  }
}