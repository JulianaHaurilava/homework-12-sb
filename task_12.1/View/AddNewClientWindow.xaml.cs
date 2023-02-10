using System.Windows;
using task_12._1.ViewModel;

namespace task_12._1.View
{
    /// <summary>
    /// Interaction logic for AddNewClientWindow.xaml
    /// </summary>
    public partial class AddNewClientWindow : Window
    {
        AddClientViewModel vm;
        public AddNewClientWindow()
        {
            InitializeComponent();
            vm = new AddClientViewModel();
        }
    }
}
