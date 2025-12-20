using MoneyTracker.Messaging.Abstractions.Models;

namespace MoneyTracker.Messaging.Abstractions
{
	public interface IMessageHandler<TMessage>
    {
        Task HandleAsync(
            TMessage message,
            CancellationToken cancellationToken);
    }
}