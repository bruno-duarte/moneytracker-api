using Confluent.Kafka;
using Microsoft.Extensions.Options;
using MoneyTracker.Messaging.Abstractions;
using MoneyTracker.Messaging.Abstractions.Models;
using MoneyTracker.Messaging.Kafka.Configuration;

namespace MoneyTracker.Messaging.Kafka.Internal.Producer
{
    public sealed class KafkaProducer : IMessageProducer, IDisposable
    {
        private readonly IProducer<Null, string> _producer;
        private readonly IMessageSerializer _serializer;

        public KafkaProducer(
            IOptions<KafkaConnectionOptions> kafkaOptions,
            IMessageSerializer serializer)
        {
            var options = kafkaOptions.Value;

            var cfg = new ProducerConfig
            {
                BootstrapServers = options.BootstrapServers,
                ClientId = options.ClientId
            };

            _producer = new ProducerBuilder<Null, string>(cfg).Build();
            _serializer = serializer;
        }

        public Task PublishAsync(
            string topic,
            MessageEnvelope message,
            CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(topic);
            ArgumentNullException.ThrowIfNull(message);

            var payload = _serializer.Serialize(message);

            return _producer.ProduceAsync(
                topic,
                new Message<Null, string> { Value = payload },
                cancellationToken
            );
        }

        public void Dispose()
        {
            _producer.Flush(TimeSpan.FromSeconds(5));
            _producer.Dispose();
        }
    }
}
