using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Windows.Forms;

namespace WinFormUIProducer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }                
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MainForm>();
            services.AddScoped<IRabbitMQService, RabbitMQService>();
        }
    }
}
