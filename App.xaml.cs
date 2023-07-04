using Firebase.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            /*_host = Host.
                CreateDefaultBuilder().
                ConfigureServices((context, service) =>
                {
                    string fireBaseApiKey = context.Configuration.GetValue<string>("FIREBASE_API_KEY");

                    service.AddSingleton (new FirebaseAuthProvider(new FirebaseConfig(fireBaseApiKey)));

                    service.AddSingleton<MainWindow>((services) => new MainWindow());
                })
                .Build();*/
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            /*MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);*/
        }
    }
}
