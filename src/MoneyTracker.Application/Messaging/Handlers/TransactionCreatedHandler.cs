using MoneyTracker.Application.Services.Interfaces;
using MoneyTracker.Domain.Events;
using MoneyTracker.Messaging.Abstractions;

namespace MoneyTracker.Application.Messaging.Handlers
{
	public class TransactionCreatedHandler(ITransactionService service) : IMessageHandler<TransactionCreatedEvent>
    {
        public async Task HandleAsync(
            TransactionCreatedEvent message,
            CancellationToken cancellationToken)
        {
            await service.ProcessCreatedTransactionEventAsync(message, cancellationToken);
        }
    }
}