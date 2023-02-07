using System.Windows;


namespace task_12._1
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
            Client client = new Client("Check", "Check", "Check", "+375445424749", "FF", "111111");
            vm.AddNewClient(client);
        }
    }
}
