using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PasswordsValidationTestTask.ViewModels;
using PasswordsValidationTestTask.Models.Services;

namespace PasswordsValidationTestTask
{
    public class Program
    {
        [STAThread]
        public static void Main() 
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IPasswordStringsProviderService, PasswordStringsProviderService>();
                    services.AddSingleton<IPasswordStringValidator, PasswordStringValidator>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<MainWindow>(serv =>
                        new MainWindow { DataContext = serv.GetRequiredService<MainViewModel>() });
                    services.AddSingleton<App>();
                })
                .Build();

            var app = host.Services.GetRequiredService<App>();

            app.Run();
        }
    }
}
