using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using task_12._1.Model;
using task_12._1.ViewModel;

namespace task_12._1.View
{
    /// <summary>
    /// Interaction logic for AddNewClientWindow.xaml
    /// </summary>
    public partial class AddNewClientWindow : Window
    {
        public AddClientViewModel vm { get; set; }
        public AddNewClientWindow()
        {
            InitializeComponent();
            //vm = new AddClientViewModel();
        }
        public AddNewClientWindow(ObservableCollection<Client> clients)
        {
            vm = new AddClientViewModel(clients);
        }

        private void bAddNewClient_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
