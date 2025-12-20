namespace MoneyTracker.Messaging.Kafka.Configuration
{
	public sealed class KafkaConsumerOptions
	{
        public string Topic { get; init; } = default!;
        public string GroupId { get; init; } = default!;
        public bool EnableAutoCommit { get; init; } = false;
        public string DeadLetterTopic { get; init; } = default!;
	}
}