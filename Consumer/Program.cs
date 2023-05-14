using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Services;
using System;
using System.Text;

namespace Consumer
{
    internal class Program
    {
        private static RabbitMQService _rabbitMQService = new RabbitMQService();

        static void Main(string[] args)
        {
            //Bağlantı açık değilse ve boş ise blok'a giriyor.
            if (_rabbitMQService.connection == null || !_rabbitMQService.connection.IsOpen)
            {
                //Bağlantıyı oluşturuyoruz.
                _rabbitMQService.CreateConnection();
                //Kanalı oluşturuyoruz.
                _rabbitMQService.CreateChannel();               

                //Direct tipi ile exchange oluşturuyoruz.
                _rabbitMQService.channel.ExchangeDeclare(Queues.MessageCreateExchange, "direct");

                //Kuyruğumuzu oluşturuyoruz
                _rabbitMQService.channel.QueueDeclare(Queues.CreateMessage, false, false, false);
                //Oluşturduğumuz kuyruk ile exhange'i birbirleriyle bağlıyoruz.
                _rabbitMQService.channel.QueueBind(Queues.CreateMessage, Queues.MessageCreateExchange, Queues.CreateMessage);

                //Kuyruğun dinlendiğini bildiriyoruz.
                Console.WriteLine($"{Queues.CreateMessage} listening...");
            }
            
            //Oluşturduğumuz kanala event nesnesi oluşturup gelen mesajları dinlemeye başlıyoruz.
            EventingBasicConsumer eventingBasicConsumer = new EventingBasicConsumer(_rabbitMQService.channel);
            eventingBasicConsumer.Received += EventingBasicConsumer_Received;

            //Mesajın geldğini producer'a bildirip oluşturduğumuz evente gidip mesajı ekrana basıyoruz.
            _rabbitMQService.channel.BasicConsume(Queues.CreateMessage, true, eventingBasicConsumer);

            Console.ReadLine();
        }

        private static void EventingBasicConsumer_Received(object sender, BasicDeliverEventArgs e)
        {
            //Gelen mesaj byte array olduğundan UTF8 ile string'e convert ediyor ve ekrana bastırıyoruz.
            Console.WriteLine(Encoding.UTF8.GetString(e.Body.ToArray()));
        }
    }
}
