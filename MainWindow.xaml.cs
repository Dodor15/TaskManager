using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Classes;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHost _host;
        public MainWindow()
        {

            var aunth = "AIzaSyCod5K4OGWQv_sgQDJqFGZlzB3YBno7VJg";
            var fairbaseClient = new FirebaseClient(
                "<URL>", new FirebaseOptions()
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(aunth)
                });

            InitializeComponent();


        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var config = new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyCod5K4OGWQv_sgQDJqFGZlzB3YBno7VJg",
                AuthDomain = "capitanchiki3.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };

            FirebaseAuthClient firebaseAuthClient = new FirebaseAuthClient(config);
            
            try
            {
                var u = firebaseAuthClient.SignInWithEmailAndPasswordAsync(email.Text, password.Text).Result.User.Uid;
                if (u != null)
                {

                    var wt = new windowTasks(u);
                    wt.Show();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Неправильная почта или пароль");
            }
            

            
            
            
        }
    }
}
