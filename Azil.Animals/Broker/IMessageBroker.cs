using RabbitMQ.Client;

namespace Azil.Animals.Broker
{
    public interface IMessageBroker
    {
        void Publish<T>(T message);
        public IConnection CreateConnection();
    }
}
