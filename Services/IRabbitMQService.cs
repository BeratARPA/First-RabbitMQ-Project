using RabbitMQ.Client;

namespace Services
{
    public interface IRabbitMQService
    {
        IConnection connection { get; set; }
        IModel channel { get; set; }

        void CreateChannel();
        void CreateConnection();
        void WriteToQueue(string queueName, string message);
    }
}
