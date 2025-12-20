using Confluent.Kafka;
using MoneyTracker.Messaging.Abstractions;
using MoneyTracker.Messaging.Abstractions.Models;
using MoneyTracker.Messaging.Kafka.Configuration;

namespace MoneyTracker.Messaging.Kafka.Internal.DeadLetter
{
	internal sealed class KafkaDeadLetterPublisher(
        ProducerConfig config,
        KafkaConsumerOptions options,
        IMessageSerializer serializer)
        : IDeadLetterPublisher
    {
        public async Task PublishAsync(
            MessageEnvelope message,
            Exception exception,
            CancellationToken cancellationToken)
        {
            using var producer =
                new ProducerBuilder<Null, string>(config).Build();

            var payload = serializer.Serialize(
                message with
                {
                    Headers = new Dictionary<string, string>
                    {
                        ["dlq.reason"] = exception.Message
                    }
                });

            await producer.ProduceAsync(
                options.DeadLetterTopic,
                new Message<Null, string> { Value = payload },
                cancellationToken);
        }
    }
}