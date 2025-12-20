using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MoneyTracker.Messaging.Kafka.Configuration;

namespace MoneyTracker.Messaging.Kafka.Extensions
{
	internal static class KafkaProducerConfigExtensions
	{
        internal static IServiceCollection AddKafkaProducerConfig(
            this IServiceCollection services)
        {
            services.AddSingleton(sp =>
            {
                var options = sp.GetRequiredService<IOptions<KafkaConnectionOptions>>().Value;

                return new ProducerConfig
                {
                    BootstrapServers = options.BootstrapServers,
                    ClientId = options.ClientId
                };
            });

            return services;
        }
	}
}