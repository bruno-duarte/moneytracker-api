using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MoneyTracker.Messaging.Abstractions;
using MoneyTracker.Messaging.Abstractions.Models;
using MoneyTracker.Messaging.Kafka.Configuration;
using System.Text.Json;

namespace MoneyTracker.Messaging.Kafka.Internal.Consumer
{
    public sealed class KafkaConsumer<TMessage>(
        KafkaConsumerOptions options,
        IOptions<KafkaConnectionOptions> connectionOptions,
        IServiceScopeFactory scopeFactory,
        IMessageSerializer serializer,
        IDeadLetterPublisher deadLetterPublisher)
        : BackgroundService, IMessageConsumer
        where TMessage : class
    {
        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            var cfg = new ConsumerConfig
            {
                BootstrapServers = connectionOptions.Value.BootstrapServers,
                GroupId = options.GroupId,
                EnableAutoCommit = options.EnableAutoCommit,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer =
                new ConsumerBuilder<Ignore, string>(cfg).Build();

            consumer.Subscribe(options.Topic);

            while (!stoppingToken.IsCancellationRequested)
            {
                ConsumeResult<Ignore, string>? result = null;

                try
                {
                    result = consumer.Consume(stoppingToken);

                    var envelope = serializer.Deserialize<MessageEnvelope>(result.Message.Value);

                    var payloadJson = ExtractPayloadJson(envelope.Payload);

                    var message = JsonSerializer.Deserialize<TMessage>(payloadJson);

                    using var scope = scopeFactory.CreateScope();

                    var handler =
                        scope.ServiceProvider
                             .GetRequiredService<IMessageHandler<TMessage>>();

                    await handler.HandleAsync(
                        message,
                        stoppingToken);

                    consumer.Commit(result);
                }
                catch (Exception ex)
                {
                    if (result is not null)
                    {
                        var dlqEnvelope = new MessageEnvelope
                        {
                            MessageType = typeof(TMessage).Name,
                            Payload = result.Message.Value,
                            Headers = new Dictionary<string, string>
                            {
                                ["error"] = ex.Message
                            }
                        };

                        await deadLetterPublisher.PublishAsync(
                            dlqEnvelope,
                            ex,
                            stoppingToken);

                        consumer.Commit(result);
                    }
                }
            }
        }

        private static string ExtractPayloadJson(object payload)
        {
            return payload switch
            {
                JsonElement json => json.GetRawText(),
                string str => str,
                _ => throw new InvalidOperationException(
                    $"Invalid payload type: {payload.GetType().Name}")
            };
        }
    }
}
