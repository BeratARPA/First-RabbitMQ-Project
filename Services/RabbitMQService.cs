using RabbitMQ.Client;
using System;
using System.Text;

namespace Services
{
    public class RabbitMQService : IRabbitMQService
    {
        public IConnection connection { get; set; }
        public IModel channel { get; set; }

        public void WriteToQueue(string queueName, string message)
        {
            //Gelen mesajı byte'a ceviriyoruz ve bir byte array'in içine atıyoruz.
            byte[] messageArray = Encoding.UTF8.GetBytes(message);

            //Hangi exchange ile hangi kuyruga iletilecek onları belirleyip byte array yaptığımız mesajı BasicPublish metotu ile gönderiyoruz.
            channel.BasicPublish(Queues.MessageCreateExchange, queueName, null, messageArray);
        }

        public void CreateChannel()
        {
            //Mesajımızın kullanacağı kanalı oluşturuyoruz.
            channel = connection.CreateModel();
        }

        public void CreateConnection()
        {
            //ConnectionFactory nesnesi oluşturup uri özelliğine rabbitmq urimizi atıyoruz.
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri("amqps://xujyfxwp:sxpPfqM5ISy5H_khs2zUD-vt5smb4Cmp@beaver.rmq.cloudamqp.com/xujyfxwp")
            };

            //CreateConnection metotu ile oluşturduğumuz bağlantıyı connection değişkenimize atıyoruz.
            connection = connectionFactory.CreateConnection();
        }
    }
}
