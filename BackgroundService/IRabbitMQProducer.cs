namespace LightHeight.BackgroundService
{
    /// <summary>
    /// This is the contract to configure the message queue
    /// </summary>
    public interface IRabbitMQProducer
    {
        public void SendOrderMessage<T> (T message);
    }
}
