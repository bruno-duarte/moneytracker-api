namespace MoneyTracker.Messaging.Kafka.Configuration
{
	public class KafkaConnectionOptions
	{
        public string BootstrapServers { get; init; } = default!;
        public string ClientId { get; init; } = default!;
	}
}