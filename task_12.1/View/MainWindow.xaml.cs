using System;
using System.Collections.Generic;
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

namespace task_12._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new ViewModel();
        }

        private void AddNewClient(object sender, RoutedEventArgs e)
        {
            Client client = new Client("Check", "Check", "Check", "+375445424749", "FF", "111111");
            vm.AddNewClient(client);
        }
    }
}
