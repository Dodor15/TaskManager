using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using TaskManager.Classes;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для windowTasks.xaml
    /// </summary>
    public partial class windowTasks : Window
    {
        int listViewItemsCount;   //Переменная для хранения размера коллекции Items
        string user;
        ObservableCollection<Tasks> tasks1 = new ObservableCollection<Tasks>();
        public windowTasks(string u)
        {
            user = u;
            /*var aunth = "AIzaSyCod5K4OGWQv_sgQDJqFGZlzB3YBno7VJg";
            var fairbaseClient = new FirebaseClient(
                "<URL>", new FirebaseOptions()
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(aunth)
                });

            var firebase = new FirebaseClient("capitanchiki3.firebaseapp.com");
            var tasks =  firebase
                .Child($"{u}/Tasks")
                .OnceAsync<Tasks>();*/

            InitializeComponent();

            DataContext = tasks1;
            listViewItemsCount = listView1.Items.Count;   //Запоминаем размер коллекции Items
        }
        string[] id = new string[4] { "2z03SvNcpCMfhy8uVwi4JtSpwEy1", "NacTNuiwABacH5j4jDqEpNDF5a92", "U6kFBJJd9XYBwDRhyRgAtfVEuSr1", "emW7qNP7DqcV4nuuFQiaCq1420G2" };

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var aunth = "AIzaSyCod5K4OGWQv_sgQDJqFGZlzB3YBno7VJg";
            var fairbaseClient = new FirebaseClient(
                "<URL>", new FirebaseOptions()
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(aunth)
                });




            var firebase = new FirebaseClient("https://capitanchiki3-default-rtdb.europe-west1.firebasedatabase.app/");
            //Users list
            List<string> login = new List<string>();
           /* var users = firebase
                .Child("Users")
                .OnceAsListAsync(l => login.Add(l));*/






            for (int i = 0; i < id.Length; i++)
            {
                string user = id[i];
                var tasks = firebase
                    .Child("User")
                    .Child(user)
                    .Child("Tasks")
                    .AsObservable<Tasks>()
                    .Subscribe(t => Dispatcher.Invoke(() =>
                    {
                        t.Object.UserId = user;
                        var current = tasks1.FirstOrDefault(task => task.Id == t.Key);
                       
                        if (current != null)
                        {
                            tasks1.Remove(current);
                        }

                        t.Object.Id = t.Key;
                        tasks1.Add(t.Object);
                        /*tasks1.OrderBy(t => t.DateTime)*/
                    }));
            }
            /*.OrderByKey()
            .StartAt("Task1")
            .OnceAsync<Tasks>();

       // var tasks1 = new List<Tasks>();
        foreach (var task in tasks)
        {
            string date = task.Object.DateTime.ToString();
            string destr = task.Object.Description.ToString();
            string executor = task.Object.ExecutorTask.ToString();
            string name = task.Object.NameTask.ToString();
            int stat = task.Object.Status;
            Tasks test = new Tasks()
            {
                Status = stat,
                DateTime = date,
                NameTask = name,
                 ExecutorTask = executor,
                 Description = destr
            };
            tasks1.Add(test);
        }

        DataContext = tasks1;*/
        }

        private void NotDone_Click(object sender, RoutedEventArgs e)
        {
            var firebase = new FirebaseClient("https://capitanchiki3-default-rtdb.europe-west1.firebasedatabase.app/");

            var button = sender as Button;
            var how= button.DataContext as Tasks;
            

            how.Status = 0;


            var task = firebase
            .Child("User")
            .Child(how.UserId)
            .Child("Tasks")
            .Child(how.Id)
            .PutAsync(how);
                

            
           

            
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            var firebase = new FirebaseClient("https://capitanchiki3-default-rtdb.europe-west1.firebasedatabase.app/");

            var button = sender as Button;
            var how = button.DataContext as Tasks;
            how.Status = 2;

            var task = firebase
            .Child("User")
            .Child(how.UserId)
            .Child("Tasks")
            .Child(how.Id)
            .PutAsync(how);
        }
    }
}
