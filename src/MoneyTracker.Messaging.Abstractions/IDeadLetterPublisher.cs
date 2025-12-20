using MoneyTracker.Messaging.Abstractions.Models;

namespace MoneyTracker.Messaging.Abstractions
{
	public interface IDeadLetterPublisher
	{
        Task PublishAsync(
        MessageEnvelope message,
        Exception exception,
        CancellationToken cancellationToken);
	}
}