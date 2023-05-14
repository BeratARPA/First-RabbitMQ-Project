using RabbitMQ.Client;
using Services;
using System;
using System.Windows.Forms;

namespace WinFormUIProducer
{
    public partial class MainForm : Form
    {
        private readonly IRabbitMQService _rabbitMQService;

        public MainForm(IRabbitMQService rabbitMQService)
        {
            InitializeComponent();
            _rabbitMQService = rabbitMQService;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Bağlantı açık değilse ve boş ise bloga giriyor.
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

                //Bağlantının açıldığının log bilgisini gönderiyoruz.
                AddLog("Connection is open now");

                btnSendMessage.Enabled = true;
            }
        }

        private void AddLog(string logMessage)
        {
            //Log bilgisini listbox'a ekliyoruz.
            lstBoxLog.Items.Add($"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] - {logMessage}");
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            //Textbox boş değilse giriyor blok'a.
            if (!string.IsNullOrEmpty(txtBoxMessage.Text))
            {
                //Mesaj gönderme isteği yapıyoruz ilgili kuyruğa.
                _rabbitMQService.WriteToQueue(Queues.CreateMessage, txtBoxMessage.Text);
                //Mesajın gönderildiğinin log bilgisini gönderiyoruz.
                AddLog("Message Published");
            }
        }
    }
}
