using System.Windows;
using task_12._1.Model;
using task_12._1.ViewModel;

namespace task_12._1.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainViewModel();
        }

        private void AddNewClient(object sender, RoutedEventArgs e)
        {
            AddNewClientWindow addNewClientWindow = new AddNewClientWindow
            {
                Owner = this,
                v.ClientsCollection = ClientsCollection
            };
            addNewClientWindow.ShowDialog();
        }
    }
}
