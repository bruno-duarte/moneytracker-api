using Microsoft.Extensions.DependencyInjection;
using MoneyTracker.Messaging.Abstractions;
using MoneyTracker.Messaging.Abstractions.Internal.Serialization;
using MoneyTracker.Messaging.Kafka.Configuration;
using MoneyTracker.Messaging.Kafka.Internal.Consumer;
using MoneyTracker.Messaging.Kafka.Internal.DeadLetter;
using MoneyTracker.Messaging.Kafka.Internal.Producer;

namespace MoneyTracker.Messaging.Kafka.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddKafkaMessaging(this IServiceCollection services, Action<KafkaConnectionOptions> configure)
    {
      services.Configure(configure);

      services.AddSingleton<IMessageSerializer, JsonMessageSerializer>();
      services.AddSingleton<IMessageProducer, KafkaProducer>();

      return services;
    }

    public static IServiceCollection AddKafkaConsumer<TMessage, THandler>(
        this IServiceCollection services,
        KafkaConsumerOptions options)
        where TMessage : class
        where THandler : class, IMessageHandler<TMessage>
    {
        services.AddSingleton(options);

        services.AddScoped<IMessageHandler<TMessage>, THandler>();

        services.AddSingleton<KafkaConsumer<TMessage>>();
        services.AddHostedService(sp => sp.GetRequiredService<KafkaConsumer<TMessage>>());

        return services;
    }

    public static IServiceCollection AddKafkaDeadLetterPublisher(
      this IServiceCollection services)
    {
        services.AddKafkaProducerConfig();

        services.AddSingleton<IDeadLetterPublisher, KafkaDeadLetterPublisher>();

        return services;
    }
  }
}