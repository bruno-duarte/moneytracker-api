namespace MoneyTracker.Messaging.Abstractions
{
	public interface IMessageSerializer
	{
        string Serialize<T>(T message);
        T Deserialize<T>(string payload);
	}
}